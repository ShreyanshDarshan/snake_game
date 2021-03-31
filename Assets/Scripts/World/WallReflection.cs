using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallReflection : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody;

    // called when snake's trigger collider hits the wall
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // check if the snake hit the top or bottom wall
        if (collision.tag == "TopWall" || collision.tag == "BottomWall")
        {
            Debug.Log("horizontal wall hit");
            // reflect the snake's velocity
            rigidbody.velocity *= new Vector2(1, -1);
        }
        // check if the snake hit the left or right wall
        if (collision.tag == "LeftWall" || collision.tag == "RightWall")
        {
            Debug.Log("vertical wall hit");
            // reflect the snake's velocity
            rigidbody.velocity *= new Vector2(-1, 1);
        }
    }
}
