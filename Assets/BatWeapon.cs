using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatWeapon : MonoBehaviour {

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with projectile");
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Collided with projectile");

            // reverse rocket direction
            // set explosion time
            collision.gameObject.GetComponent<Rocket>().HitByBat();

            //RocketFactory.DestroyRocket(collision.gameObject);
        }
    }
}
