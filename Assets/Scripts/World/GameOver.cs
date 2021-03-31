using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] TileGeneration tilegen;

    // Update is called once per frame
    void Update()
    {
        // If all tiles are walked over already, game ends
        if (tilegen.GetNumUnwalked() == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
