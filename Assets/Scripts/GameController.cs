using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject loseMenu;
    [SerializeField] private Text score;

    private void Start()
    {
        Screen.fullScreen = false;
        Time.timeScale = 1;
    }
    public void OnEnableLoseMenu()
    {
        loseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ScoreUpdate(int amountOfCoins)
    {
        score.text = amountOfCoins.ToString();
    }
}
