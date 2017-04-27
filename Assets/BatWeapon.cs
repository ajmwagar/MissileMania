using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BatWeapon : MonoBehaviour {
    public AudioSource audioSource;

	private float lowPitchRange = .75F;
	private float highPitchRange = 1.1F;
	private float velToVol = .15F;
	private float velocityClipSplit = 10F;

    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //Debug.Log(gameObject.name + " collided with " + collision.gameObject.name);


            var rocketScript = collision.gameObject.GetComponent<Rocket>();
            if (rocketScript == null)
            {
                // ROCKET HIT BULLET
                BulletFactory.DestroyBullet(collision.gameObject);
                var thisRocketScript = gameObject.GetComponent<Rocket>();

                if(thisRocketScript != null)
                {
                    thisRocketScript.HitByOther();
                }
                return;
            }

            // BAT HIT ROCKET
            // OR ROCKET HIT ROCKET
            // reverse rocket direction
            // set explosion time
            collision.gameObject.GetComponent<Rocket>().HitByBat();

			audioSource.pitch = Random.Range(lowPitchRange, highPitchRange);
			float hitVol = collision.relativeVelocity.magnitude * velToVol;
            if (hitVol > 1f) { hitVol = 1f; }

            // don't play the bat sound if one has just started playing
            if (audioSource.isPlaying && audioSource.timeSamples < 3000)
            {
                return;
            }

            audioSource.PlayOneShot(SoundFX.BatHitFx, hitVol); 

            CollectableTaken();

            //audioSource.pitch = Random.Range(0.8f, 1.2f);
            //audioSource.volume = hitVol;
            //RocketFactory.DestroyRocket(collision.gameObject);
        } else if (collision.gameObject.tag == "Other")
            {
                //Debug.Log("Collided with projectile");

                // reverse rocket direction
                // set explosion time
                collision.gameObject.GetComponent<Rocket>().HitByOther();

                audioSource.pitch = Random.Range(lowPitchRange, highPitchRange);
                float hitVol = collision.relativeVelocity.magnitude * velToVol;

                audioSource.PlayOneShot(SoundFX.MissileExplosion, hitVol);

                //audioSource.pitch = Random.Range(0.8f, 1.2f);
                //audioSource.volume = hitVol;
                //RocketFactory.DestroyRocket(collision.gameObject);
            }

    }

    //This method is called from the Collectable script when the player
    //picks it up
    public void CollectableTaken()
    {
        //If the GameManager exists, tell it that the player scored a point
        if (GameManager.instance != null)
            GameManager.instance.PlayerScored();
    }
}
