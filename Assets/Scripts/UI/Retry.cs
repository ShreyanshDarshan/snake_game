using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    // Load scene again to retry the game
    public void RetryGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Game");
    }
}
