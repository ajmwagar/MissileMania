using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{

    private static GameMusic _instance;
    private static GameMusic Instance { get { return _instance; } }

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
        // do turn on/off correct music level at the beginning of the music loop
    }
}