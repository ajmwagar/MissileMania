using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatWeapon : MonoBehaviour {

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            Debug.Log("Collided with projectile");

            // reverse rocket direction
            // set explosion time
            collision.gameObject.GetComponent<Rocket>().HitByBat();

            //RocketFactory.DestroyRocket(collision.gameObject);
        }
    }
}
