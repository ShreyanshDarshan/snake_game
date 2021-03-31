using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] float Life;
    // Start is called before the first frame update
    void Start()
    {
        // Destroy after life seconds
        Destroy(gameObject, Life);
    }
}
