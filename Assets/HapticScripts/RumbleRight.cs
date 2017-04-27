using NullSpace.SDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RumbleRight : MonoBehaviour {
    HapticSequence rumbl = new HapticSequence();
    HapticSequence buzz = new HapticSequence();

	// Use this for initialization
	void Start () {
    rumbl.LoadFromAsset("Haptic/buzz");
    buzz.LoadFromAsset("Haptic/fuzz");


    }


    // Update is called once per frame
    void OnTriggerEnter(Collision collision){
      rumbl.CreateHandle(AreaFlag.Right_All).Play();
      Debug.Log("Working");

     }

  void OnCollisionEnter (Collision collision){
      rumbl.CreateHandle(AreaFlag.Right_All).Play();
      Debug.Log(collision.gameObject + "collided with" + gameObject);
     }

  }
