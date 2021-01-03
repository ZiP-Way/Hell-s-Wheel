using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseSystem : MonoBehaviour
{
     protected GameController gameController;
    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }
}
