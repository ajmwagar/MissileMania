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
        transform.rotation = Quaternion.LookRotation(rb.velocity) * Quaternion.Euler(rocketRotation);

        audioSource.clip = SoundFX.MissileTravel;
        audioSource.loop = true;
        audioSource.Play();
    }
    public void explodeRocket()
    {
        BoomStick.SetActive(true);
        Debug.Log("Boom?");
        audioSource.PlayOneShot(SoundFX.MissileExplosion);
    }
    public void DexplodeRocket()
    {
        BoomStick.SetActive(false);
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
    public void HitByOther()
    {
        Target = null;
        rocketType = RocketType.HitByOther;

        rb.velocity = rb.velocity * -2;

        explodeInSec = 0f;
        destroyInSec = 5 + explodeInSec;
    }
    private void FixedUpdate()
    {
        if(rocketType == RocketType.Guided)
        {
            rb.velocity = (Target.transform.position - transform.position).normalized * speed;
            transform.rotation = Quaternion.LookRotation(rb.velocity) * Quaternion.Euler(rocketRotation);
        }
        else if(rocketType == RocketType.HitByBat || rocketType == RocketType.HitByOther)
        {

            var rot = rb.rotation;
            rot.z += 100 * Time.fixedDeltaTime;
            rb.rotation.Set(rot.x, rot.y, rot.z, rot.w);

            explodeInSec -= Time.fixedDeltaTime;
            destroyInSec -= Time.fixedDeltaTime;
            if (explodeInSec < 0)
            {
                audioSource.Stop();
                explodeRocket();
                explodeInSec = 1000;
            }

            if(destroyInSec < 0)
            {
                RocketFactory.DestroyRocket(gameObject);
                DexplodeRocket();
      
                destroyInSec = 1000;

            }
        }
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "Bat")
        {
            Debug.Log("Collided with projectile");

            // reverse rocket direction
            // set explosion time
            collision.gameObject.GetComponent<Rocket>().HitByOther();

            audioSource.PlayOneShot(SoundFX.BatHitFx);
            audioSource.pitch = Random.Range(0.8f, 1.2f);
            audioSource.volume = audioSource.volume * Random.Range(0.6f, 1f);
            //RocketFactory.DestroyRocket(collision.gameObject);
        }
    }
}
