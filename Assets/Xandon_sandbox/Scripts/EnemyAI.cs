using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	public Transform posA;
	public Transform posB;
	public float speed;
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(posA.position, posB.position, Mathf.Sin(Time.time* speed));
	}
}
