using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHealth : MonoBehaviour {

	public float turretHealth = 100f;

	public void TakeDamage(){
		turretHealth -= 20f;
		if (turretHealth < 0f) {
			KillTurret ();
			turretHealth = 0f;
		}
	}


	private void KillTurret() {


	}


	public void RepairTurret(){
		if (turretHealth < 100f) {
			turretHealth += 10f;
			if (turretHealth >= 100f) {
				TurretRepaired ();
				turretHealth = 100f;
			}
		}
	}

	private void TurretRepaired (){


	}

}
