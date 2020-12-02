using UnityEngine;
using System.Collections;

public class MyTileMap : MonoBehaviour
{
    private MyGrid<TileMapObject> grid;

    public MyTileMap(int width, int height, float cellSize, Vector3 originPosition)
    {
        grid = new MyGrid<TileMapObject>(width, height, cellSize, originPosition);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                grid.gridArray[x, y] = new TileMapObject(x, y, cellSize);
                grid.gridArray[x, y].SetXY(x, y);
            }
        }
    }
    // Overloaded constructor for setting all sprites
    public MyTileMap(int width, int height, float cellSize, Vector3 originPosition, Sprite t_sprite)
    {
        grid = new MyGrid<TileMapObject>(width, height, cellSize, originPosition);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                grid.gridArray[x, y] = new TileMapObject(x, y, cellSize);
                grid.gridArray[x, y].SetXY(x, y);
                grid.gridArray[x, y].SetTileMapSprite(t_sprite);
            }
        }
    }

}
