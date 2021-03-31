using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFood : MonoBehaviour
{
    // reference to UI script of counting food items eaten
    FoodCount foodCount;
    // to prevent double counting
    bool hasCollided = false;
    [SerializeField] GameObject EatEffect;
    // Start is called before the first frame update
    void Start()
    {
        foodCount = GameObject.FindGameObjectsWithTag("Counter")[0].GetComponent<FoodCount>();
    }

    // called when a trigger collider hits the food item
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if the trigger collider is form the head of the snake, then add to the food counter and destroy self
        if (collision.tag == "SnakeHead" && hasCollided == false)
        {
            foodCount.FoodCounter += 1;
            Instantiate(EatEffect, new Vector3(transform.position.x, transform.position.y, -0.5f), Quaternion.identity);
            Destroy(gameObject);
            hasCollided = true;
        }
    }
}
