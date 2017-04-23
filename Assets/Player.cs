using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger!!! " + other.gameObject.tag);
        if (other.gameObject.tag == "Enemy")
        {
            RocketFactory.DestroyRocket(other.gameObject);
        }
    }
}
