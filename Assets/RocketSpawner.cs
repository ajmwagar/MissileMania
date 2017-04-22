using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : MonoBehaviour {

    public GameObject Target;
    public KeyCode FireRocketKey;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(FireRocketKey))
        {
            Debug.Log("Spawn rocket request...");
            Spawn(RocketType.Simple);
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
