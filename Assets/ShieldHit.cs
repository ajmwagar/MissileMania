using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldHit : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip shieldCrash;

    private float lowPitchRange = .75F;
    private float highPitchRange = 1.5F;
    private float velToVol = 2.0F;
    private float velocityClipSplit = 2F;

    // Use this for initialization
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void OnCollisionEnter(Collision other)
    {
        
        //audioSource.pitch = Random.Range(lowPitchRange, highPitchRange);
        float hitVol = other.relativeVelocity.magnitude * velToVol;

        audioSource.PlayOneShot(shieldCrash, hitVol);
    }

}
