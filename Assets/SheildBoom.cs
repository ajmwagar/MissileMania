using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheildBoom : MonoBehaviour {

    public GameObject ShieldSphere;
    public AudioSource audioSource;

    private float lowPitchRange = .75F;
    private float highPitchRange = 1.1F;
    private float velToVol = .08F;
    private float velocityClipSplit = 2F;

    // Use this for initialization
    void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Rocket>().HitByBat();

        audioSource.pitch = Random.Range(lowPitchRange, highPitchRange);
        float hitVol = collision.relativeVelocity.magnitude * velToVol;
        if (hitVol > 1) { hitVol = 1; }

        audioSource.PlayOneShot(SoundFX.BatHitFx, hitVol);
    }


}
