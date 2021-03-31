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
    private List<GameObject> Tiles; 

    // Awake is called before Start, so it helps get things set up before other scripts access the tile data
    void Awake()
    {
        Tiles = new List<GameObject>();
        
        // spawning tiles in an N x M grid
        for (int i=0; i<M; i++)
        {
            for (int j=0; j<N; j++)
            {
                Vector3 tile_spawn_pos = new Vector3(i, j, 0) * TileWidth;
                // storing the spawned tile in the list
                Tiles.Add( Instantiate(tile, tile_spawn_pos, Quaternion.identity, transform) );
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
        top_wall.tag = "TopWall";

        // spawning the bottom wall
        Vector3 bottom_wall_scale = new Vector3(M, 0, 0) * TileWidth + WallWidthOffset;
        Vector3 bottom_wall_pos = new Vector3(M / 2.0f, 0, 0) * TileWidth - TileWidthOffset / 2 - HorizontalWallWidthOffset / 2;
        GameObject bottom_wall = Instantiate(wall, bottom_wall_pos, Quaternion.identity);
        bottom_wall.transform.localScale = bottom_wall_scale;
        bottom_wall.tag = "BottomWall";

        // spawning the left wall
        Vector3 left_wall_scale = new Vector3(0, N, 0) * TileWidth + WallWidthOffset;
        Vector3 left_wall_pos = new Vector3(0, N / 2.0f, 0) * TileWidth - TileWidthOffset / 2 + VerticalWallWidthOffset / 2;
        GameObject left_wall = Instantiate(wall, left_wall_pos, Quaternion.identity);
        left_wall.transform.localScale = left_wall_scale;
        left_wall.tag = "LeftWall";

        // spawning the right wall
        Vector3 right_wall_scale = new Vector3(0, N, 0) * TileWidth + WallWidthOffset;
        Vector3 right_wall_pos = new Vector3(M, N / 2.0f, 0) * TileWidth - TileWidthOffset / 2 - VerticalWallWidthOffset / 2;
        GameObject right_wall = Instantiate(wall, right_wall_pos, Quaternion.identity);
        right_wall.transform.localScale = right_wall_scale;
        right_wall.tag = "RightWall";
    }

    public Vector2 GetRandomPosition()
    {
        // get a random number smaller than the size of the tiles list
        int randomVal = Random.Range(0, Tiles.Count);
        int index = 0;
        int counter = 0;
        int valid_index;
        // spin a roullette of all the unwalked tiles by that random number
        while (counter < randomVal)
        {
            valid_index = index % Tiles.Count;
            if (Tiles[valid_index].GetComponent<ChangeTileColor>().isWalked == false)
            {
                counter += 1;
            }
            index += 1;
        }
        // return the position of the tile on which the roullette lands
        valid_index = (index-1) % Tiles.Count;
        return Tiles[valid_index].transform.position;
    }

    // function to give number of unwalked tiles
    public int GetNumUnwalked()
    {
        int numWalkedTiles = 0;
        foreach (GameObject tile in Tiles)
        {
            if (tile.GetComponent<ChangeTileColor>().isWalked == false)
            {
                // for each unwalked tile, add to the count
                numWalkedTiles += 1;
            }
        }
        return numWalkedTiles;
    }
}
