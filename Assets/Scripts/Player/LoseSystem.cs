using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseSystem : MonoBehaviour
{
    protected GameController gameController;
    protected WheelController wheelController;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
        wheelController = GameObject.FindGameObjectWithTag("Player").GetComponent<WheelController>();
    }
}
