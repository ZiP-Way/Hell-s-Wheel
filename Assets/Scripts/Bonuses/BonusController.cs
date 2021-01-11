using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour
{
    [SerializeField] private GameObject gameController;
    [SerializeField] private GameObject magnetCollider;
    [SerializeField] private float timeToDisableMagnet;

    protected GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Magnet"))
        {
            StartCoroutine(TimerToDisable(timeToDisableMagnet));
            Destroy(other.gameObject);
        }
    }

    private IEnumerator TimerToDisable(float seconds)
    {
        magnetCollider.SetActive(true);

        yield return new WaitForSecondsRealtime(seconds);

        magnetCollider.SetActive(false);
    }
}
