using UnityEngine;
using System.Collections;

public class MyTileMap : MonoBehaviour
{
    private MyGrid<TileMapObject> grid;
    public static int[,] mapSpriteIndex = new int[10,5];
    public Sprite[] spriteArray;
    static bool isCustomMap = new bool();

    public MyTileMap() { }
    public MyTileMap(int width, int height, float cellSize, Vector3 originPosition)
    {
        spriteArray = Resources.LoadAll<Sprite>("Sprites/");// load sprite assets
        grid = new MyGrid<TileMapObject>(width, height, cellSize, originPosition);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                grid.gridArray[x, y] = new TileMapObject(x, y, cellSize);
                grid.gridArray[x, y].SetXY(x, y);
            }
        }
        mapSpriteIndex = new int[width, height];
    }
    // Overloaded constructor for setting all sprites
    public MyTileMap(int width, int height, float cellSize, Vector3 originPosition, Sprite t_sprite)
    {
        spriteArray = Resources.LoadAll<Sprite>("Sprites/");// load sprite assets
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
        mapSpriteIndex = new int[width, height];
        if (isCustomMap)
        {
            setUpSavedMap();
        }
    }

    public void setMapSpriteIndex(int x, int y, int value)
    {
        mapSpriteIndex[x, y] = value;
    }

    public void setUpSavedMap()
    { 
        for (int x = 0; x < grid.GetWorldWidth(); x++)
        {
            for (int y = 0; y < grid.GetWorldHeight(); y++)
            {
                grid.gridArray[x, y].SetTileMapSprite(spriteArray[mapSpriteIndex[x, y]]);
            }
        }
    }
    public void useCustomMap()
    {
        isCustomMap = true;
    }
}
