using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Rocket : MonoBehaviour {

    public KeyCode DestroyKey = KeyCode.Alpha1;

    public GameObject Target;
    public float speed;
    public Rigidbody rb;
    public RocketType rocketType;
    public Vector3 rocketRotation;
    public float explodeInSec;
    public float destroyInSec;
    public GameObject BoomStick;
    public AudioSource audioSource;

    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update () {
		if(Input.GetKeyUp(DestroyKey))
        {
            RocketFactory.DestroyRocket(gameObject);
        }
	}

    public void Initialize(RocketType type, GameObject target)
    {
        rocketType = type;
        Target = target;

        rb.velocity = (Target.transform.position - transform.position).normalized * speed;

        audioSource.clip = SoundFX.MissileTravel;
        audioSource.loop = true;
        audioSource.Play();
    }
    public void explodeRocket()
    {
      //  BoomStick.SetActive(true);
        Debug.Log("Boom?");
        audioSource.loop = false;
        audioSource.clip = null;
        audioSource.PlayOneShot(SoundFX.MissileExplosion);
    }
    public void DexplodeRocket()
    {
        // BoomStick.SetActive(false);
        Debug.Log("UnBoom?");
    }
    public void HitByBat()
    {
        Target = null;
        rocketType = RocketType.HitByBat;

        rb.velocity = rb.velocity * -2;
        
        explodeInSec = 3f;
        destroyInSec = 5 + explodeInSec;
    }

    private void FixedUpdate()
    {
        if(rocketType == RocketType.Guided)
        {
            rb.velocity = (Target.transform.position - transform.position).normalized * speed;
            transform.rotation = Quaternion.LookRotation(rb.velocity) * Quaternion.Euler(rocketRotation);
        }
        else if(rocketType == RocketType.HitByBat)
        {
            audioSource.Stop();
            var rot = rb.rotation;
            rot.z += 100 * Time.fixedDeltaTime;
            rb.rotation = rot;

            explodeInSec -= Time.fixedDeltaTime;
            destroyInSec -= Time.fixedDeltaTime;
            if (explodeInSec < 0)
            {
                explodeRocket();
                Debug.Log("Exploded!");
                explodeInSec = 1000;
            }

            if(destroyInSec < 0)
            {
                RocketFactory.DestroyRocket(gameObject);
                DexplodeRocket();
                Debug.Log("Dexploded!");
                destroyInSec = 1000;
            }
        }
        
    }
}
