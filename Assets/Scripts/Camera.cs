using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [Range(0, 0.2f)]
    [SerializeField] private float cameraSpeed;
    private void FixedUpdate()
    {
        if (player.GetComponent<WheelController>().PlayerSide == Side.Right)
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, 1.6f, cameraSpeed), Mathf.Lerp(transform.position.y, player.transform.position.y + 3.5f, cameraSpeed), player.transform.position.z - 3f);
        }
        else if (player.GetComponent<WheelController>().PlayerSide == Side.Left)
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, -0.9f, cameraSpeed), Mathf.Lerp(transform.position.y, player.transform.position.y + 3.5f, cameraSpeed), player.transform.position.z - 3f);
        }
        else if (player.GetComponent<WheelController>().PlayerSide == Side.Middle)
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, 0.25f, cameraSpeed), Mathf.Lerp(transform.position.y, player.transform.position.y + 3.5f, cameraSpeed), player.transform.position.z - 3f);
        }

        //transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z - 3f);
    }
}
