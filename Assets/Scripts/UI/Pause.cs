using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject HiddenUI;
    
    // unhide hidden gui and set timescale to 0 to pause the game
    public void PauseGame()
    {
        // pause the game
        Time.timeScale = 0.0f;
        // unhide the hidden ui buttons
        HiddenUI.SetActive(true);
        // hide the pause button
        gameObject.SetActive(false);
    }
}
