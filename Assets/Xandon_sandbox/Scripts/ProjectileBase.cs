using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileBase : MonoBehaviour {
	public float speed = 1000.0f;

	public abstract void FireProjectile(GameObject launcher, GameObject target, int damage, float attackSpeed);
}
