using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BatWeapon : MonoBehaviour {
    public AudioSource audioSource;

    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Collided with projectile");

            // reverse rocket direction
            // set explosion time
            collision.gameObject.GetComponent<Rocket>().HitByBat();

            audioSource.PlayOneShot(SoundFX.BatHitFx);
            audioSource.pitch = Random.Range(0.8f, 1.2f);
            audioSource.volume = audioSource.volume*Random.Range(0.6f, 1f);
            //RocketFactory.DestroyRocket(collision.gameObject);
        }
    }
}
