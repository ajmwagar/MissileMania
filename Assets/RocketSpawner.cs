using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : MonoBehaviour {

    public List<GameObject> rocketList;
	// Use this for initialization
	void Start () {
        rocketList = new List<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.S))
        {
            Debug.Log("Spawn rocket request...");
            Spawn();
        }
    }

    public void Spawn()
    {
        var rocket = RocketFactory.Instance.CreateRocket();
        rocketList.Add(rocket);
        Debug.Log("Rocket Spaned!!!!");
    }
}
