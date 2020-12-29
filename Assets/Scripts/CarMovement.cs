using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    private void FixedUpdate()
    {
        transform.position += Vector3.back * movementSpeed;
    }
}
