using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    public KeyCode DestroyKey = KeyCode.Alpha1;

    public GameObject Target;
    public float speed;
    public Rigidbody rb;
    public RocketType rocketType;
    public Vector3 rocketRotation;
    public float explodeInSec;

    private void Awake()
    {
       rb = gameObject.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update () {
		if(Input.GetKeyUp(DestroyKey))
        {
            RocketFactory.DestroyRocket(gameObject);
        }
	}

    public void Initialize(RocketType type, GameObject target)
    {
        rocketType = type;
        Target = target;

        rb.velocity = (Target.transform.position - transform.position).normalized * speed;
    }

    public void HitByBat()
    {
        Target = null;
        rocketType = RocketType.HitByBat;

        rb.velocity = rb.velocity * -2;
        
        explodeInSec = 3f;
    }

    private void FixedUpdate()
    {
        if(rocketType == RocketType.Guided)
        {
            rb.velocity = (Target.transform.position - transform.position).normalized * speed;
            transform.rotation = Quaternion.LookRotation(rb.velocity) * Quaternion.Euler(rocketRotation);
        }
        else if(rocketType == RocketType.HitByBat)
        {
            var rot = rb.rotation;
            rot.z += 100 * Time.fixedDeltaTime;
            rb.rotation = rot;

            explodeInSec -= Time.fixedDeltaTime;
            if(explodeInSec < 0)
            {
                RocketFactory.DestroyRocket(gameObject);
            }
        }
        
    }
}
