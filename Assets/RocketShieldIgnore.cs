using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketShieldIgnore : MonoBehaviour {

    public bool isHit;
    [SerializeField]
    private LayerMask whatIsRocket;
    [SerializeField]
    public Transform[] ShieldPoints;
    [SerializeField]
    public float ShieldRadius;
    public GameObject SCB;


    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	

        private void IsHit()
    {
        if (gameObject.transform.position.y >= 0)
        {
            foreach (Transform point in ShieldPoints)
            {
                Collider[] colliders = Physics.OverlapSphere(point.position, ShieldRadius, whatIsRocket);
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        isHit = true;
                        return;
                    }
                }
            }
        }
        isHit = false;
    }
    public void FixedUpdate()
    {
        IsHit();
    }

    public void Update()
    {
           if (isHit)
        {
            SCB.SetActive(true);
        }
     if (!isHit)
        {
            SCB.SetActive(true);
        }
    }
}


