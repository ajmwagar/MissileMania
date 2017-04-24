using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : MonoBehaviour {

    public GameObject Target;
    public KeyCode FireSimple = KeyCode.A;
    public KeyCode ChangeRockeType = KeyCode.Tab;
    public int FrameCount = 0;

    public RocketType rocketType;

    public AudioSource audioSource;

    public float intervalRangeMin;
    public float intervalRangeMax;

    public float fireCountDown;

    public void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {

        FrameCount += 1;
        if (Input.GetKeyDown(FireSimple))
        {
            //Debug.Log("Spawn rocket request...");
            Spawn(rocketType);

        }

        if (Input.GetKeyUp(ChangeRockeType))
        {
            if(rocketType == RocketType.Simple)
            {
                rocketType = RocketType.Guided;
            }
            else
            {
                rocketType = RocketType.Simple;
            }

            //Debug.Log("Now Spawning: " + rocketType.ToString());
        }

        fireCountDown -= Time.deltaTime;

        if(fireCountDown < 0)
        {
            Spawn(rocketType);
            fireCountDown = Random.Range(intervalRangeMin, intervalRangeMax);
        }
    }

    public void Spawn(RocketType type)
    {
        var rocket = RocketFactory.CreateRocket(type);
        rocket.transform.position = gameObject.transform.position;
        rocket.GetComponent<Rocket>().Initialize(type, Target);
        audioSource.PlayOneShot(SoundFX.MissileLaunch);
        //Debug.Log("Rocket Spaned!!!!");
    }
}
