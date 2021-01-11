using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [Range(0f, 5.0f)]
    [SerializeField] private float moveObjSpeed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            other.gameObject.GetComponent<Coin>().MoveToPlayer(moveObjSpeed);
        }
    }
}
