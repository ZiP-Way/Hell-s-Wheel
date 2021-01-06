using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardBorder : LoseSystem
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            gameController.OnEnableLoseMenu();
        }
        else if (other.CompareTag("Magnet"))
        {

        }
    }
}
