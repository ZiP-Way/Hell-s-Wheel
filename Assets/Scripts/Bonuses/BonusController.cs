using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour
{
    [SerializeField] protected GameObject player;
    protected WheelController wheelControllerScript;

    [SerializeField] private GameObject gameController;
    [SerializeField] private GameObject magnetCollider;

    [SerializeField] private float timeToDisableMagnet;
    [SerializeField] private float timeToDisableSpeedBoost;

    private void Awake()
    {
        wheelControllerScript = player.GetComponent<WheelController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Magnet"))
        {
            StartCoroutine(TimerToDisableMg(timeToDisableMagnet));
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("SpeedBoost"))
        {
            StartCoroutine(TimerToDisableSB(timeToDisableSpeedBoost));
            Destroy(other.gameObject);
        }
    }

    private IEnumerator TimerToDisableMg(float waitTime)
    {
        magnetCollider.SetActive(true);
        yield return new WaitForSecondsRealtime(waitTime);
        magnetCollider.SetActive(false);
    }

    private IEnumerator TimerToDisableSB(float waitTime)
    {
        player.GetComponent<WheelController>().PlayerBonusStatus = PlayerBonus.SpeedBoost;
        wheelControllerScript.MoveFowardSpeed += 5; 
        yield return new WaitForSecondsRealtime(waitTime);
        wheelControllerScript.MoveFowardSpeed -= 5;
        player.GetComponent<WheelController>().PlayerBonusStatus = PlayerBonus.Default;
    }
}
