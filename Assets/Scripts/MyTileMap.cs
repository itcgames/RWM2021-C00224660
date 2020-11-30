using UnityEngine;
using System.Collections;
// Author: Josh Browne
public class MyTileMap 
{
    public MyTileMap(int width, int height, float cellSize, Vector3 originPosition)
    {
        spriteSelection = new SpriteSelection(width * cellSize, height * cellSize, cellSize, height * cellSize, cellSize);
        currentSprite = spriteSelection.spriteArray[0];
        currentSprite.rect.size.Set(cellSize, cellSize);
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
    private MyGrid<TileMapObject> grid;
    private Sprite currentSprite; // this is the sprite which is used for setting a tile sprite
    private SpriteSelection spriteSelection;

    public void SetTileSprite(Vector3 worldPosition, Sprite sprite)
    {
        TileMapObject tileMapObject = grid.getValueAtPos(worldPosition);
        if (tileMapObject.tileGameObject != null)
        {
            tileMapObject.SetTileMapSprite(sprite);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //spriteSelection = new SpriteSelection();
        //currentSprite = spriteSelection.spriteArray[0];
    }

    // Update is called once per frame
    public void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            Sprite check = spriteSelection.checkMouseClickOnSpriteSelection(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if (check != null)
            {
                currentSprite = check;
            }
            else
            {
                SetTileSprite(Camera.main.ScreenToWorldPoint(Input.mousePosition), currentSprite); // try to set a map tile
            }
        }
    }

}
