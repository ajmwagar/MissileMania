using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFX : MonoBehaviour {
    private static SoundFX _instance;
    private static SoundFX Instance { get { return _instance; } }

    public AudioClip missileLaunch;
    public AudioClip missileTravel;
    public AudioClip missileExplosion;

    public AudioClip bigTurretFire;
    public AudioClip bigTurretMovement;
    public AudioClip bigTurretStay;

    public AudioClip smallTurretFire;
    public AudioClip smallTurretMovement;
    public AudioClip smallTurretStay;

    public AudioClip batHitFx;

    public AudioClip powerToolFx;

    public static AudioClip MissileLaunch { get { return Instance.missileLaunch; } }
    public static AudioClip MissileTravel { get { return Instance.missileTravel; } }
    public static AudioClip MissileExplosion { get { return Instance.missileExplosion; } }

    public static AudioClip BigTurretFire { get { return Instance.bigTurretFire; } }
    public static AudioClip BigTurretMovement { get { return Instance.bigTurretMovement; } }
    public static AudioClip BigTurretStay { get { return Instance.bigTurretStay; } }

    public static AudioClip SmallTurretFire { get { return Instance.smallTurretFire; } }
    public static AudioClip SmallTurretMovement { get { return Instance.smallTurretMovement; } }
    public static AudioClip SmallTurretStay { get { return Instance.smallTurretStay; } }

    public static AudioClip BatHitFx { get { return Instance.batHitFx; } }
    public static AudioClip PowerToolFx { get { return Instance.powerToolFx; } }


    public static void SetGameMusicLevel(int level)
    {

    }

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
}
