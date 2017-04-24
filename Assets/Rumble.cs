using NullSpace.SDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rumble : MonoBehaviour {
    HapticSequence rumbl = new HapticSequence();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnCollisionEnter () {

        rumbl.LoadFromAsset("Haptic/Buzz");
    }
}
