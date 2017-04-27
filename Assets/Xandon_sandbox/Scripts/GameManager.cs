//This script handles the logic and UI for our game. It controls how much time the player has,
//how many points they have scored, and it detects when the player has won or lost the game

using UnityEngine;
using UnityEngine.UI;				//Enable UI items in script
using UnityEngine.SceneManagement;	//Enable scene management in script
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    //This class contains a public static reference to itself. This means that it 
    //will be accessible to other classes globally, even if they don't have a 
    //reference or link to it. 
    public static GameManager instance;

    [Header("Game Properties")]
    public int scoreToWin = 500;      //Amount of points the player needs to lower the wall
    public float timeAmount = 0.01f;  //How long the player has to reach the goal
    public float levelTime = 180f;  //How long the player has to reach the goal
    public AudioMixerSnapshot introSnapshot;
    public AudioMixerSnapshot playSnapshot;


    [Header("UI Elements")]
    public Text timeText;           //The UI element that shows the amount of time
    public Text collectText;        //The UI element that shows the player's score
    public GameObject menuPanel;     //The panel that will pop up when the player wins
    public GameObject winPanel;     //The panel that will pop up when the player wins	
    public GameObject lossPanel;    //The panel that will pop up when the player loses

    int score;      //Player's current score
    bool gameover;  //Is the game over?


    void Awake()
    {
        //If there currently isn't a GameManager, make this the game manager. Otherwise,
        //destroy this object. We only want one GameManager
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        //Set our initial UI text for score and the amount of time
        collectText.text = score + " / " + scoreToWin;
        timeText.text = ((int)timeAmount).ToString();
        //StartGame();
    }

    void Update()
    {
        //Always look to see if the player is pressing the "Cancel" button (escape). If so,
        //quit the game
        if (Input.GetButtonDown("Cancel"))
            ExitGame();

        //If the game is already over, don't do anything (just leave)
        if (gameover)
            return;

        //Reduce the player's time
        timeAmount -= Time.deltaTime;

        //If the player's time is now at or below zero...
        if (timeAmount <= 0.02f)
        {
            //...set the time to zero...
            timeAmount = 0.01f;
            //...record that the game is now over...
            gameover = true;
            //...and show the Loss Panel
            lossPanel.SetActive(true);
            menuPanel.SetActive(true);
            GameMusic.Instance.SetInMenu(true);
            introSnapshot.TransitionTo(0);
        }
        else {
            lossPanel.SetActive(false);
            menuPanel.SetActive(false);
        }

        ChangeTimeScale();

        //Update the UI to show the remaining time
        timeText.text = ((int)timeAmount).ToString();
    }


    public void ChangeTimeScale()
    {

        if (score <= 20 && timeAmount < 160f && Time.timeScale > 1.0F)
        {
            Time.timeScale = 1.0F;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
        }
        else if (score <= 40 && timeAmount < 130f)
        {
            Time.timeScale = 1.0F;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
        }
        else if (score > 400)
        {
            Time.timeScale = 3.0F;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
        }
        else if (score > 200)
        {
            Time.timeScale = 2.0F;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
        }
        else if (score > 100)
        {
            Time.timeScale = 1.8F;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
        }
        else if (score > 80)
        {
            Time.timeScale = 1.5F;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
        }
        else if (score > 40)
        {
            Time.timeScale = 1.2F;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
        }


        if (timeAmount <= 0.02)
        {
            Time.timeScale = 0.01F;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
        }

    }


    //This method is called from the CollectableSpawner when the player picks up a shield
    public void PlayerScored()
    {
        //If the player already has enough points, leave. This prevents the score from
        //becoming larger than the needed score in the UI (for instance, 5 out of 4), and also
        //prevents us from trying to lower the wall multiple times
        if (score >= scoreToWin)
            return;

        //Increase the player's score and update the UI
        score++;
        collectText.text = score + " / " + scoreToWin;

        //If the player hasn't scored eough points yet, leave
        if (score < scoreToWin)
            return;

    }

    //This method is called when the player enters the goal area
    public void PlayerEnteredGoalZone()
    {
        //The game is now over
        gameover = true;
        //Show the Win Panel
        winPanel.SetActive(true);
        menuPanel.SetActive(true);
        GameMusic.Instance.SetInMenu(true);
        introSnapshot.TransitionTo(0);
        playSnapshot.TransitionTo(1);
    }

    //This method is called from the Player's script. We only want the player to be
    //able to move if the game isn't over
    public bool IsGameOver()
    {
        //Return whether or not the game is over
        return gameover;
        introSnapshot.TransitionTo(1);
        playSnapshot.TransitionTo(0);
    }

    //This methid is called from the AdManager when the player watches a rewarded ad
    public void AddMoreGameTime(float amount)
    {
        //Add the given amount of time to the player's time
        timeAmount += amount;

        //If the game is already over, it is no longer over, so that the player
        //can keep trying
        if (gameover)
            gameover = false;
    }

    //This method is called from the "Play Again" buttons in the UI
    public void ReloadScene()
    {
        //Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //This method is called from the "Play Again" buttons in the UI
    public void StartGame()
    {
        score = 0;
        timeAmount = levelTime;
        Time.timeScale = 1.0F;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
        if (gameover)
        {
            gameover = false;
        }
        
        GameMusic.Instance.SetInMenu(false);
        introSnapshot.TransitionTo(0);
        playSnapshot.TransitionTo(1);
    }


    //This method allows the player to exit the game either by pressing the correct key or
    //selecting to exit the game from the UI
    public void ExitGame()
    {
        //Check to see if we are in the editor, and if we are simply stop playing
        //If we are not in the editor, then we are in a build and we need to tell the application
        //to Quit. NOTE: This does not work on all platforms. Some platforms only allow the OS to
        //terminate applications and in those cases Application.Quit() won't do anything
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
    }
}
