using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour {

    public GameManager GameManager;
    public string ButtonName;

    // Use this for initialization
    void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Bat")
        {
            if (ButtonName == "RestartGame")
            {
                Debug.Log("Restart!!!!");
                GameManager.ReloadScene();
                
            }
            else if(ButtonName == "QuitGame")
            {
                Debug.Log("Exit!!!!");
                GameManager.ExitGame();
            }
            else if (ButtonName == "StartGame")
            {
                Debug.Log("Start!!!!");
                GameManager.StartGame();
            }
        }
    }
}
