using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        
    }

    public void CarPush(Vector3 pushWay)
    {
        rb.isKinematic = false;
        rb.velocity = pushWay;
    }
}
