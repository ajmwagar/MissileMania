using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{

    public float rotationSpeed = 0.1f;


    void Update()
    {
        transform.Rotate(0, 6.0f * rotationSpeed * Time.deltaTime, 0);
    }
}
