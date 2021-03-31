using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    // set timescale to normal to resume game
    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
    }
}
