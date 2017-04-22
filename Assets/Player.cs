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


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision!!! " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Projectile")
        {
            RocketFactory.Instance.DestroyRocket(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger!!! " + other.gameObject.tag);
        if (other.gameObject.tag == "Projectile")
        {
            RocketFactory.Instance.DestroyRocket(other.gameObject);
        }
    }
}
