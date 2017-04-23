using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BatWeapon : MonoBehaviour {
    public AudioSource audioSource;

	private float lowPitchRange = .75F;
	private float highPitchRange = 1.5F;
	private float velToVol = .2F;
	private float velocityClipSplit = 10F;

    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //Debug.Log("Collided with projectile");

            // reverse rocket direction
            // set explosion time
            collision.gameObject.GetComponent<Rocket>().HitByBat();

			audioSource.pitch = Random.Range(lowPitchRange, highPitchRange);
			float hitVol = collision.relativeVelocity.magnitude * velToVol;

			audioSource.PlayOneShot(SoundFX.BatHitFx, hitVol);

            //audioSource.pitch = Random.Range(0.8f, 1.2f);
			//audioSource.volume = hitVol;
            //RocketFactory.DestroyRocket(collision.gameObject);
        }
    }
}
