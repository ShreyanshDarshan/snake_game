using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeSpawn : MonoBehaviour
{
    [SerializeField] TileGeneration tilegen;

    // Start is called before the first frame update
    void Start()
    {
        // spawn the snake at the center of the world
        transform.position = new Vector3(tilegen.M / 2.0f, tilegen.M / 2.0f, -0.5f);
    }
}
