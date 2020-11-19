using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    private Grid grid;
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
        grid = new Grid(tileWidth, tileHeight, cellSize, mapOriginPosition);
        Camera.main.transform.position = mapOriginPosition + new Vector3((tileWidth * cellSize) / 2, (tileHeight * cellSize) / 2, -10);
        //Camera.main.transform.localScale.Set(2, 2,2);
    }

    // Update is called once per frame
    void Update()
    {
        grid.Update();
    }
}
