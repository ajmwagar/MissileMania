using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : MonoBehaviour {

    public List<GameObject> rocketList;
    public GameObject Target;

    public KeyCode FireRocketKey;

    public float speed = 20f;

	// Use this for initialization
	void Start () {
        rocketList = new List<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(FireRocketKey))
        {
            Debug.Log("Spawn rocket request...");
            Spawn();
        }
    }

    public void Spawn()
    {
        var rocket = RocketFactory.Instance.CreateRocket();
        rocketList.Add(rocket);

        var rb = rocket.GetComponent<Rigidbody>();

        rocket.transform.position = gameObject.transform.position;
        rb.velocity = (Target.transform.position - transform.position).normalized * speed;
        //rb.velocity.y = 0;
        Debug.Log("Rocket Spaned!!!!");
    }
}
