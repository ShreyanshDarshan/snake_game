using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawning : MonoBehaviour
{
    [SerializeField] TileGeneration tilegen;
    [SerializeField] GameObject FoodPrefab;
    [SerializeField] float foodLife = 4.0f;
    [SerializeField] float cooldown = 2.0f;
    bool isSpawnCycleRunning;

    IEnumerator SpawnFood()
    {
        // spawncycle begins
        isSpawnCycleRunning = true;

        //yield on a new YieldInstruction that waits for cooldown time.
        yield return new WaitForSeconds(cooldown);
     
        // get random position to spawn food on from tilegen
        Vector2 spawnPos = tilegen.GetRandomPosition();

        // spawn the food item at above obtained random location on unwalked tiles
        GameObject food = Instantiate(FoodPrefab, new Vector3 (spawnPos.x, spawnPos.y, -0.5f), Quaternion.identity);

        //yield on a new YieldInstruction that waits for foodlife time.
        yield return new WaitForSeconds(foodLife);

        // if snake has not eaten food, destroy it
        if (food)
        {
            Destroy(food);
        }
        
        // spawncycle complete
        isSpawnCycleRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if spawn food coroutine is not running
        if (isSpawnCycleRunning == false)
        {
            // start spawn food cycle
            StartCoroutine(SpawnFood());
        }
    }
}
