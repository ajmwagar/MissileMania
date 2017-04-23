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

    public float minDelay;
    public float maxDelay;
    public float fireCountdown;

    public void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        minDelay = Random.Range(3, 5);
        maxDelay = Random.Range(6, 8);
        fireCountdown = 2;
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

        fireCountdown -= Time.deltaTime;
        if(fireCountdown < 0)
        {
            Spawn(rocketType);
            fireCountdown = Random.Range(minDelay, maxDelay);
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
