using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : MonoBehaviour {

    public GameObject Target;
    public KeyCode FireSimple = KeyCode.A;
    public KeyCode ChangeRockeType = KeyCode.Tab;

    public RocketType rocketType;

    // Update is called once per frame
    void Update () {
		if(Input.GetKeyUp(FireSimple))
        {
            Debug.Log("Spawn rocket request...");
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

            Debug.Log("Now Spawning: " + rocketType.ToString());
        }
    }

    public void Spawn(RocketType type)
    {
        var rocket = RocketFactory.CreateRocket(type);
        rocket.transform.position = gameObject.transform.position;
        rocket.GetComponent<Rocket>().Initialize(type, Target);

        //rb.velocity.y = 0;
        Debug.Log("Rocket Spaned!!!!");
    }
}
