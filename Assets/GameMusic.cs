using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{

    private static GameMusic _instance;
    private static GameMusic Instance { get { return _instance; } }

    [Range(0.5f, 1f)]
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
        if(GameMusicLevels[0].time > StartPlayingAtSec)
        {
            return;
        }

        // do turn on/off correct music level at the beginning of the music loop
        for (int i = 1; i < GameMusicLevels.Length -1; i++)
        {
            if(i <= currentLevel)
            {
                GameMusicLevels[i].Play();
                GameMusicLevels[i].time = GameMusicLevels[0].time;
            }
            else
            {
                GameMusicLevels[i].Stop();
            }
        }
    }
}