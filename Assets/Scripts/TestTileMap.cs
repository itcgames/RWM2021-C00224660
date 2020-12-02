using UnityEngine;
using System.Collections;

public class TestTileMap : MonoBehaviour
{
    private MyTileMap tileMap;
    private int gridWidth;
    private int gridHeight;
    private float cellSize;
    private Vector3 mapOriginPosition;
    private Sprite initialTileSprite;

    // Start is called before the first frame update
    void Start()
    {
        initialTileSprite = Resources.Load<Sprite>("Sprites/grassTileDark");
        gridWidth = 16;
        gridHeight = 9;
        cellSize = 1f;
        mapOriginPosition = new Vector3(0, 0, 0);  // set origin
        tileMap = new MyTileMap(gridWidth, gridHeight, cellSize, mapOriginPosition, initialTileSprite);
        Camera.main.transform.position = mapOriginPosition + new Vector3((gridWidth * cellSize) / 2, (gridHeight * cellSize) / 2, -10);
    }

}
