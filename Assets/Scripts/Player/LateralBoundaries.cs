using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateralBoundaries : LoseSystem
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car") && wheelController.PlayerBonusStatus != PlayerBonus.SpeedBoost)
        {
            wheelController.TakeDamage();
        }
        else if(wheelController.PlayerBonusStatus == PlayerBonus.SpeedBoost)
        {
            Debug.Log("hi");
        }
    }
}
