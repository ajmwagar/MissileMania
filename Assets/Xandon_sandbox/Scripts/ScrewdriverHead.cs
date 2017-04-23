using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewdriverHead : MonoBehaviour {
	public Vector3 screwSpeed;

	public void Update(){
		transform.Rotate(screwSpeed);
	}
}
