using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDelayer : MonoBehaviour
{
    private AudioSource audio;

	void Start ()
    {
        audio = this.GetComponent<AudioSource>();
        StartCoroutine(AudioDelay());
	}


    IEnumerator AudioDelay()
    {
        yield return new WaitForSeconds(16f);
        audio.Play();
    }
}
