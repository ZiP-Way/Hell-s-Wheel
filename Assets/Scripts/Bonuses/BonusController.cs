using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour
{
    [SerializeField] private GameObject gameController;

    [SerializeField] private GameObject magnetCollider;

    [SerializeField] private float timeToDisableMagnet;

    private int coinCount = 0;
    private float timer = 0;

    protected GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        magnetCollider.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (magnetCollider.activeSelf)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                magnetCollider.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coinCount++;
            gameController.GetComponent<GameController>().ScoreUpdate(coinCount);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Magnet"))
        {
            timer = timeToDisableMagnet;
            magnetCollider.SetActive(true);
            Destroy(other.gameObject);
        }
    }
}
