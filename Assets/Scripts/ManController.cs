using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManController : MonoBehaviour
{
    [HideInInspector] public bool IsRunningFaster;

    [SerializeField] private GameObject player;
    [SerializeField] private float speed;

    private float distanceValue = 1;
    private Vector3 manPos;

    void FixedUpdate()
    {
        if (player.GetComponent<WheelController>().PlayerSide != Side.Middle)
        {
            if (IsRunningFaster)
            {
                distanceValue = 1;
                // 0.4f the difference between the height of the wheel and the man
                manPos = new Vector3(player.transform.position.x, player.transform.position.y + 0.4f, player.transform.position.z - 1f);
            }
            else
            {
                if (distanceValue < 3.5f)
                {
                    manPos = new Vector3(player.transform.position.x, player.transform.position.y + 0.4f, player.transform.position.z - distanceValue);
                    distanceValue += Time.deltaTime;
                }
                else
                {
                    manPos = new Vector3(player.transform.position.x, player.transform.position.y + 0.4f, player.transform.position.z - 3.5f);
                }
            }
        }
        else
        {
            if (IsRunningFaster)
            {
                manPos = new Vector3(0, player.transform.position.y + 0.4f, player.transform.position.z - 1f);
            }
            else
            {
                if (distanceValue < 3.5f)
                {
                    manPos = new Vector3(0, player.transform.position.y + 0.4f, player.transform.position.z - distanceValue);
                    distanceValue += Time.deltaTime;
                }
                else
                {
                    manPos = new Vector3(0, player.transform.position.y + 0.4f, player.transform.position.z - 3.5f);
                }
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, manPos, speed);
    }
}
