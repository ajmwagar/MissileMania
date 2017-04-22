using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger!!! " + other.gameObject.tag);
        if (other.gameObject.tag == "Projectile")
        {
            RocketFactory.DestroyRocket(other.gameObject);
        }
    }
}
