using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToUseSoundFx_Example : MonoBehaviour {

    public AudioSource audioSource;

    public KeyCode PlayLaunch;
    public KeyCode PlayTravel;
    public KeyCode PlayExplosion;
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetKeyUp(PlayLaunch))
        {
            Debug.Log("Launch Missile!");
            audioSource.PlayOneShot(SoundFX.MissileLaunch);
            audioSource.loop = false;
        }

        if (Input.GetKeyUp(PlayTravel))
        {
            Debug.Log("Traveling!");
            audioSource.clip = SoundFX.MissileTravel;
            audioSource.Play();
            audioSource.loop = true;
        }

        if (Input.GetKeyUp(PlayExplosion))
        {
            Debug.Log("KAAABOOOOM Missile!!!");
            audioSource.clip = SoundFX.MissileExplosion;
            audioSource.Play();
            audioSource.loop = false;
        }
    }
}
