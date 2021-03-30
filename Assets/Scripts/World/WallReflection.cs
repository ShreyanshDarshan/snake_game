using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallReflection : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "TopWall" || collision.tag == "BottomWall")
        {
            Debug.Log("horizontal");
            rigidbody.velocity *= new Vector2(1, -1);
        }
        if (collision.tag == "LeftWall" || collision.tag == "RightWall")
        {
            Debug.Log("vertical");
            rigidbody.velocity *= new Vector2(-1, 1);
        }
    }
}
