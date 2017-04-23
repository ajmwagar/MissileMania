using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBoom : MonoBehaviour {
    public GameObject BoomStick;

	// Use this for initialization
	public void explodeRocket()
    {
        BoomStick.SetActive(true);	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
