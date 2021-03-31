using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTileColor : MonoBehaviour
{
    // Green color material to which tile will be changed once walked on
    [SerializeField] Material GreenMat;
    SpriteRenderer spriteRenderer;
    public bool isWalked;   // stores whether the tile has been already walked on
    private void Start()
    {
        isWalked = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // if snake collides with the tile
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // check whether it is the snake indeed
        if (collision.tag == "Snake" || collision.tag == "SnakeHead")
        {
            // change material
            spriteRenderer.material = GreenMat;
            isWalked = true;
        }
    }
}
