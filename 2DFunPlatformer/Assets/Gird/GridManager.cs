using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    //Designate the width and height of the grid
    [SerializeField] private int width, height;
    [SerializeField] private Tile tile;

    [SerializeField] private List<Tile> tileList = new List<Tile>();

    [SerializeField] private Transform cam;

    private void Start()
    {
        CreateGrid();
    }
    private void CreateGrid()
    {
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                //Create the tile at the given positions for the width and the height
                var spawnedTile = Instantiate(tile, new Vector2(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";

                tileList.Add(spawnedTile);

                var offset = (x % 2 == 0 && y % 2 != 0 || x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(offset);
            }
        }
        //Move the camera so that the origin (0, 0, 0) is in the bottom left corner
        //cam.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);
    }

}
