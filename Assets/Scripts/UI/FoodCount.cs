using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FoodCount : MonoBehaviour
{
    // integer storing number of food items eaten
    public int FoodCounter;
    TextMeshProUGUI CountText;
    // Start is called before the first frame update
    void Start()
    {
        CountText = GetComponent<TextMeshProUGUI>();
        FoodCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // set the UI text to show how many food items eaten till now
        CountText.text = "x " + FoodCounter.ToString();
    }
}
