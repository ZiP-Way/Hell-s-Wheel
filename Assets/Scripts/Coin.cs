using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up*rotationSpeed);
    }
}
