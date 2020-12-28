using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject loseMenu;

    private void Start()
    {
        Time.timeScale = 1;
    }
    public void OnEnableLoseMenu()
    {
        loseMenu.SetActive(true);
        Time.timeScale = 0;
    }
}
