using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    // Start the game by loading the game scene
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }
}
