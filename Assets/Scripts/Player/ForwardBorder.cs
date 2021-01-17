using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardBorder : LoseSystem
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car") && wheelController.PlayerBonusStatus != PlayerBonus.SpeedBoost)
        {
            gameController.OnEnableLoseMenu();
        }
        else if (wheelController.PlayerBonusStatus == PlayerBonus.SpeedBoost)
        {
            if(wheelController.PlayerSide == Side.Middle && wheelController.SavedLastPlayerSide == Side.Right)
            {
                other.gameObject.GetComponent<Car>().CarPush(new Vector3(-5, 10, 10));
            }
            else if (wheelController.PlayerSide == Side.Middle && wheelController.SavedLastPlayerSide == Side.Left)
            {
                other.gameObject.GetComponent<Car>().CarPush(new Vector3(5, 10, 10));
            }
            else if(wheelController.PlayerSide == Side.Left && wheelController.SavedLastPlayerSide == Side.Middle)
            {
                other.gameObject.GetComponent<Car>().CarPush(new Vector3(-5, 10, 10));
            }
            else if(wheelController.PlayerSide == Side.Right && wheelController.SavedLastPlayerSide == Side.Middle)
            {
                other.gameObject.GetComponent<Car>().CarPush(new Vector3(5, 10, 10));
            }
        }
    }
}
