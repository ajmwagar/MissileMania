using NullSpace.SDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rumble : MonoBehaviour {
    HapticSequence rumbl = new HapticSequence();
	// Use this for initialization
	void Start () {
        rumbl.LoadFromAsset("Haptic/Buzz");
    }
	
	// Update is called once per frame
	void OnCollisionEnter () {

        
        rumbl.CreateHandle(AreaFlag.All_Areas).Play();
        Debug.Log("BOOM!");
    }
    void OnTriggerEnter()
    {
             rumbl.CreateHandle(AreaFlag.All_Areas).Play();
        Debug.Log("BOOM!");
       
    }
}
