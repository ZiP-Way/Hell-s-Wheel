using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsController : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private int amountOfRoadObjects = 0;
    private int amountOfDistance = 0;
    private void Start()
    {
        amountOfRoadObjects = GameObject.FindGameObjectsWithTag("Road").Length;
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(0, 0, player.transform.position.z - 20);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Road"))
        {
            other.transform.position = new Vector3(0, 0, 10 * (amountOfRoadObjects - 1) + amountOfDistance);
            amountOfDistance += 10;
        }
        else if (other.CompareTag("Car"))
        {
            other.transform.position += new Vector3(0,0,50);
        }
    }
}
