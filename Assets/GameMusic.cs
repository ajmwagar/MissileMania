using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{

    private static GameMusic _instance;
    private static GameMusic Instance { get { return _instance; } }

    [Range(0.01f, 1f)]
    public float StartPlayingAtSec;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        GameMusicLevels[0].Play();
    }

    public static void SetGameMusicLevel(int level)
    {
        if (level < 0)
        {
            level = 0;
        }
        else if (level >= Instance.GameMusicLevels.Length)
        {
            level = Instance.GameMusicLevels.Length - 1;
        }
    }

    public int currentLevel;
    public AudioSource[] GameMusicLevels;

    public void Update()
    {

        if (currentLevel == 0)
        {
            // playing intro music which doesn't get layered
            
            if (!GameMusicLevels[0].isPlaying)
            {
                // stop all the other music layers
                for (int i = 1; i < GameMusicLevels.Length; i++)
                {
                    GameMusicLevels[i].Stop();
                }
                GameMusicLevels[0].Play();
            }
        }
        else
        {
            // playing in play music which is layered so loop through the layers to turn the right ones on
            GameMusicLevels[0].Stop();

            if (!GameMusicLevels[1].isPlaying) { GameMusicLevels[1].Play(); }
            
            if (GameMusicLevels[1].time > StartPlayingAtSec)
            {
                return;
            }

            // do turn on/off correct music level at the beginning of the music loop
            for (int i = 2; i < GameMusicLevels.Length; i++)
            {
                if (i <= currentLevel)
                {
                    if (!GameMusicLevels[i].isPlaying)
                    {
                        GameMusicLevels[i].Play();
                        if (i > 1) { GameMusicLevels[i].time = GameMusicLevels[1].time; }
                    }
                }
                else
                {
                    GameMusicLevels[i].Stop();
                }
            }
        }
    }
}