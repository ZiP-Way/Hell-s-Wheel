using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z - 4);
    }
}
