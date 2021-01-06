using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : BonusController
{
    [Range(0f, 1.0f)]
    [SerializeField] private float moveObjSpeed;

    private GameObject coin;

    void FixedUpdate()
    {
        if (coin != null)
        {
            coin.transform.position = new Vector3(Mathf.Lerp(coin.transform.position.x, player.transform.position.x, moveObjSpeed),
                Mathf.Lerp(coin.transform.position.y, player.transform.position.y, moveObjSpeed),
                Mathf.Lerp(coin.transform.position.z, player.transform.position.z, moveObjSpeed));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coin = other.gameObject;
        }
    }
}
