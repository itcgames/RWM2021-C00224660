using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: Josh Browne
public class TestingTileMapEditor : MonoBehaviour
{
    private MyTileMapEditor tileMap;
    private int gridWidth;
    private int gridHeight;
    private float cellSize;
    private Vector3 mapOriginPosition;

    // Start is called before the first frame update
    void Start()
    {
        gridWidth = 16;
        gridHeight = 9;
        cellSize = 1f;
        mapOriginPosition = new Vector3(0, 0, 0);  // set origin
        float textureSelectPanelOffset = 1;
        tileMap = new MyTileMapEditor(gridWidth, gridHeight, cellSize, mapOriginPosition);
        Camera.main.transform.position = mapOriginPosition + new Vector3((gridWidth * cellSize) / 2 + textureSelectPanelOffset, (gridHeight * cellSize) / 2, -10);
    }

    // Update is called once per frame
    void Update()
    {
        tileMap.Update();
    }
}
