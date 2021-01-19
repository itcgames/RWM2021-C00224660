using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: Josh Browne
public class TestingTileMapEditor : MonoBehaviour
{
    private MyTileMapEditor tileMapEditor;
    private int gridWidth;
    private int gridHeight;
    private float cellSize;
    private Vector3 mapOriginPosition;

    // Start is called before the first frame update
    void Start()
    {
        gridWidth = 10;
        gridHeight = 5;
        cellSize = 1f;
        mapOriginPosition = new Vector3(0, 0, 0);  // set origin
        float textureSelectPanelOffset = 1;
        tileMapEditor = this.gameObject.GetComponent<MyTileMapEditor>();
        tileMapEditor.init(gridWidth, gridHeight, cellSize, mapOriginPosition, textureSelectPanelOffset);
        //Camera.main.transform.position = mapOriginPosition + new Vector3((gridWidth * cellSize) / 2 + textureSelectPanelOffset, (gridHeight * cellSize) / 2, -10);
    }

    // Update is called once per frame
    void Update()
    {
        tileMapEditor.Update();
    }
}