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
        for (int i = 0; i < GameMusicLevels.Length; i++)
        {
            GameMusicLevels[i].Play();
            if (i > 0) { GameMusicLevels[i].mute = true; }
        }
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
        if(GameMusicLevels[0].time > StartPlayingAtSec)
        {
            return;
        }

        // do turn on/off correct music level at the beginning of the music loop
        for (int i = 1; i < GameMusicLevels.Length; i++)
        {
            if(i <= currentLevel)
            {
                if (GameMusicLevels[i].mute) {
                    GameMusicLevels[i].mute = false;
                    GameMusicLevels[i].time = GameMusicLevels[0].time;
                }
            }
            else
            {
                GameMusicLevels[i].mute = true;
            }
        }
    }
}