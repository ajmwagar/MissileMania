using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    public KeyCode DestroyKey = KeyCode.Alpha1;

    bool isHoming = false;

    public GameObject Target;
    public float speed;
    public Rigidbody rb;

    private void Awake()
    {
       rb = gameObject.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update () {
		if(Input.GetKeyUp(DestroyKey))
        {
            RocketFactory.Instance.DestroyRocket(gameObject);
        }
	}

    private void FixedUpdate()
    {

        if(isHoming)
        {
                      
            rb.velocity = (Target.transform.position - transform.position).normalized * speed;
            // track player
        }    }
}
