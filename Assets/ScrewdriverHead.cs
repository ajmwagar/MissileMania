using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewdriverHead : MonoBehaviour {
	public Vector3 screwSpeed;

	// Update is called once per frame
	void Update () {
		transform.Rotate(screwSpeed);
	}
}
