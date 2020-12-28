using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
}
