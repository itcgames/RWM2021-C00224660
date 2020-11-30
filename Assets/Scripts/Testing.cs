using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: Josh Browne
public class Testing : MonoBehaviour
{
    private MyTileMap tileMap;
    private int tileWidth;
    private int tileHeight;
    private float cellSize;
    private Vector3 mapOriginPosition;

    // Start is called before the first frame update
    void Start()
    {
        tileWidth = 16;
        tileHeight = 9;
        cellSize = 1f;
        mapOriginPosition = new Vector3(0, 0, 0);  // set origin
        float textureSelectPanelOffset = 1;
        tileMap = new MyTileMap(tileWidth, tileHeight, cellSize, mapOriginPosition);
        Camera.main.transform.position = mapOriginPosition + new Vector3((tileWidth * cellSize) / 2 + textureSelectPanelOffset, (tileHeight * cellSize) / 2, -10);
    }

    // Update is called once per frame
    void Update()
    {
        tileMap.Update();
    }
}
