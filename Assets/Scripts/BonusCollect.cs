using UnityEngine;

public class BonusCollect : MonoBehaviour
{
    [SerializeField] private GameObject gameController;
    private int coinCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coinCount++;
            gameController.GetComponent<GameController>().ScoreUpdate(coinCount);
            Destroy(other.gameObject);
        }
    }
}
