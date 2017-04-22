using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    public KeyCode DestroyKey = KeyCode.Alpha1;

    public GameObject Target;
    public float speed;
    public Rigidbody rb;
    public RocketType rocketType;

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

    private void FixedUpdate()
    {
        if(rocketType == RocketType.Guided)
        {
            rb.velocity = (Target.transform.position - transform.position).normalized * speed;
        }
    }
}
