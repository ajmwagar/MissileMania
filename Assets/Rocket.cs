using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    public KeyCode DestroyKey = KeyCode.Alpha1;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(DestroyKey))
        {
            RocketFactory.Instance.DestroyRocket(gameObject);
        }
	}
}
