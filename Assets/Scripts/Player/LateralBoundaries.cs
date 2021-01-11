using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateralBoundaries : MonoBehaviour
{
    private WheelController wheelController;

    private void Start()
    {
        wheelController = GameObject.FindGameObjectWithTag("Player").GetComponent<WheelController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            wheelController.TakeDamage();
        }
    }
}
