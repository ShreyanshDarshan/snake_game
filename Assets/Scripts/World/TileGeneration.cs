using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGeneration : MonoBehaviour
{
    [SerializeField] GameObject tile;
    [SerializeField] GameObject wall;
    public int M = 10;
    public int N = 10;
    public float WallWidth = 0.3f;
    public float TileWidth = 1f;
    // Start is called before the first frame update
    void Start()
    {
        // spawning tiles in an N x M grid
        for (int i=0; i<M; i++)
        {
            for (int j=0; j<N; j++)
            {
                Vector3 tile_spawn_pos = new Vector3(i, j, 0) * TileWidth;
                Instantiate(tile, tile_spawn_pos, Quaternion.identity);
            }
        }

        // to add width and extra length to walls for covering corners
        Vector3 WallWidthOffset = new Vector3(WallWidth, WallWidth, 0);
        // to help position the walls at the edges of a tile and not the center
        Vector3 TileWidthOffset = new Vector3(TileWidth, TileWidth, 0);
        // to help position horizontal walls cover the corners
        Vector3 HorizontalWallWidthOffset = new Vector3(WallWidth, WallWidth, 0);
        // to help position vertical walls cover the corners
        Vector3 VerticalWallWidthOffset = new Vector3(-WallWidth, WallWidth, 0);

        // spawning the top wall
        Vector3 top_wall_scale = new Vector3(M, 0, 0) * TileWidth + WallWidthOffset;
        Vector3 top_wall_pos = new Vector3(M / 2.0f, N, 0) * TileWidth - TileWidthOffset / 2 + HorizontalWallWidthOffset / 2;
        GameObject top_wall = Instantiate(wall, top_wall_pos, Quaternion.identity);
        top_wall.transform.localScale = top_wall_scale;

        // spawning the bottom wall
        Vector3 bottom_wall_scale = new Vector3(M, 0, 0) * TileWidth + WallWidthOffset;
        Vector3 bottom_wall_pos = new Vector3(M / 2.0f, 0, 0) * TileWidth - TileWidthOffset / 2 - HorizontalWallWidthOffset / 2;
        GameObject bottom_wall = Instantiate(wall, bottom_wall_pos, Quaternion.identity);
        bottom_wall.transform.localScale = bottom_wall_scale;


        // spawning the left wall
        Vector3 left_wall_scale = new Vector3(0, N, 0) * TileWidth + WallWidthOffset;
        Vector3 left_wall_pos = new Vector3(0, N / 2.0f, 0) * TileWidth - TileWidthOffset / 2 + VerticalWallWidthOffset / 2;
        GameObject left_wall = Instantiate(wall, left_wall_pos, Quaternion.identity);
        left_wall.transform.localScale = left_wall_scale;

        // spawning the right wall
        Vector3 right_wall_scale = new Vector3(0, N, 0) * TileWidth + WallWidthOffset;
        Vector3 right_wall_pos = new Vector3(M, N / 2.0f, 0) * TileWidth - TileWidthOffset / 2 - VerticalWallWidthOffset / 2;
        GameObject right_wall = Instantiate(wall, right_wall_pos, Quaternion.identity);
        right_wall.transform.localScale = right_wall_scale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
