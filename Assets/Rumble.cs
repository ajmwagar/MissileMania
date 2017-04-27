using NullSpace.SDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rumble : MonoBehaviour {
    HapticSequence rumbl = new HapticSequence();
    HapticSequence buzz = new HapticSequence();
	// Use this for initialization
	void Start () {
        rumbl.LoadFromAsset("Haptic/Buzz");
        Buzz.LoadFromAsset("Haptic/Fuzz")

    }
	// Update is called once per frame
	    void OnTriggerEnter()
    {
      if(collision.gameObject.tag == enemy)
      {
            rumbl.CreateHandle(AreaFlag.All_Areas).Play();
            Debug.log(collision.gameObject.tag + "Rumble");
      }
      if (collision.gameObject.tag == shield) {
        Buzz.CreateHandle(AreaFlag.All_Areas).Play();
        Debug.log(collision.gameObject.tag + "fuzz");
      }

  }}
