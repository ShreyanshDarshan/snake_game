﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSettings : MonoBehaviour
{
    Camera cam;
    public TileGeneration tilegen;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        // to help position the camera at the center of the grid
        Vector3 TileWidthOffset = new Vector3(tilegen.TileWidth, tilegen.TileWidth, 0);
        transform.position = new Vector3(tilegen.M / 2.0f, tilegen.N / 2.0f, -1) - TileWidthOffset/2;
        Debug.Log(cam.aspect);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
