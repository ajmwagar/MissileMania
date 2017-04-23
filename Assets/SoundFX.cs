using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFX : MonoBehaviour {
    private static SoundFX _instance;
    private static SoundFX Instance { get { return _instance; } }

    [Header("Missile")]
    public AudioClip missileLaunch;
    public AudioClip missileTravel;
    public AudioClip missileExplosion;

    [Header("Turret")]
    public AudioClip bigTurretFire;
    public AudioClip bigTurretMovement;
    public AudioClip bigTurretStay;

    public AudioClip smallTurretFire;
    public AudioClip smallTurretMovement;
    public AudioClip smallTurretStay;

    public AudioClip turretDamaged;

    [Header("Misc")]
    public AudioClip batHitFx;
    public AudioClip powerToolFx;

    [Header("Shield")]
    public AudioClip shieldActive;
    public AudioClip shieldUp;
    public AudioClip shieldDown;
    public AudioClip shieldDamaged;

    public static AudioClip MissileLaunch { get { return Instance.missileLaunch; } }
    public static AudioClip MissileTravel { get { return Instance.missileTravel; } }
    public static AudioClip MissileExplosion { get { return Instance.missileExplosion; } }

    public static AudioClip BigTurretFire { get { return Instance.bigTurretFire; } }
    public static AudioClip BigTurretMovement { get { return Instance.bigTurretMovement; } }
    public static AudioClip BigTurretStay { get { return Instance.bigTurretStay; } }

    public static AudioClip SmallTurretFire { get { return Instance.smallTurretFire; } }
    public static AudioClip SmallTurretMovement { get { return Instance.smallTurretMovement; } }
    public static AudioClip SmallTurretStay { get { return Instance.smallTurretStay; } }

    public static AudioClip TurretDamaged { get { return Instance.turretDamaged; } }

    public static AudioClip BatHitFx { get { return Instance.batHitFx; } }
    public static AudioClip PowerToolFx { get { return Instance.powerToolFx; } }

    public static AudioClip ShieldActive { get { return Instance.shieldActive; } }
    public static AudioClip ShieldUp { get { return Instance.shieldUp; } }
    public static AudioClip ShieldDown { get { return Instance.shieldDown; } }
    public static AudioClip ShieldDamaged { get { return Instance.shieldDamaged; } }

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
