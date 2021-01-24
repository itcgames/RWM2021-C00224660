using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: Josh Browne
public class MyGrid<TGridObject>
{
    private int width;
    private int height;
    private float cellSize;
    public TGridObject[,] gridArray; // [,] = how to define an array with 2 dimensions
    private TextMesh[,] textArray;
    private Vector3 originPosition;

    public MyGrid(int width, int height, float cellSize, Vector3 originPosition)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        gridArray = new TGridObject[width, height];
        //textArray = new TextMesh[width, height];

        // Draw grid lines
        //for (int x = 0; x < gridArray.GetLength(0); x++)
        //{
        //    for (int y = 0; y < gridArray.GetLength(1); y++)
        //    {
        //        Debug.DrawLine(GetWorldPosition(x + (int)(originPosition.x), y + (int)(originPosition.y)), GetWorldPosition(x + (int)(originPosition.x), y + 1 + (int)(originPosition.y)), Color.white, 100f);
        //        Debug.DrawLine(GetWorldPosition(x + (int)(originPosition.x), y + (int)(originPosition.y)), GetWorldPosition(x + 1 + (int)(originPosition.x), y + (int)(originPosition.y)), Color.white, 100f);
        //    }
        //}
        //Debug.DrawLine(GetWorldPosition(0 + (int)(originPosition.x), height + (int)(originPosition.y)), GetWorldPosition(width + (int)(originPosition.x), height + (int)(originPosition.y)), Color.white, 100f);
        //Debug.DrawLine(GetWorldPosition(width + (int)(originPosition.x), 0 + (int)(originPosition.y)), GetWorldPosition(width + (int)(originPosition.x), height + (int)(originPosition.y)), Color.white, 100f);
    }

    public MyGrid()
    {
    }

    public void init(int width, int height, float cellSize, Vector3 originPosition)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        gridArray = new TGridObject[width, height];
        //textArray = new TextMesh[width, height];


        // For grid lines
        
        LineRenderer lineRenderer = GameObject.Find("CreateMapEditorGameObject").AddComponent<LineRenderer>();
        lineRenderer.enabled = true;
        lineRenderer.positionCount = 586;
        lineRenderer.SetWidth(0.05f, 0.05f);
        lineRenderer.material.color = Color.white;
        lineRenderer.startColor = Color.grey;
        lineRenderer.endColor = Color.grey;
        // Draw grid lines
        int count = 0;
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                //line stuff..
                lineRenderer.SetPosition(count, GetWorldPosition(x, y));
                count++;
                lineRenderer.SetPosition(count, GetWorldPosition(x, y + 1));
                count++;
                lineRenderer.SetPosition(count, GetWorldPosition(x + 1, y + 1));
                count++;
                lineRenderer.SetPosition(count, GetWorldPosition(x + 1, y));
                count++;
                if (y < height - 1 || x == width - 1)
                {
                    lineRenderer.SetPosition(count, GetWorldPosition(x, y));
                    count++;
                }
            }
        }
        lineRenderer.SetPosition(lineRenderer.positionCount-1, lineRenderer.GetPosition(count - 2));
    }

    // Create Text in World
    private static TextMesh CreateWorldText(Transform parent, string text, Vector3 localPosition, int fontSize, Color color, TextAnchor textAnchor, TextAlignment textAlignment)//, int sortingOrder)
    {
        GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
        Transform transform = gameObject.transform;
        transform.SetParent(parent, false);
        transform.localPosition = localPosition;
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        textMesh.alignment = textAlignment;
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        textMesh.color = color;
        //textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
        return textMesh;
    }

    //Get width
    public int GetWorldWidth()
    {
        return this.width;
    }
    //Get height
    public int GetWorldHeight()
    {
        return this.height;
    }
    //Get cell size
    public float GetWorldCellSize()
    {
        return this.cellSize;
    }
    // Get world pos of tile
    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize + originPosition;
    }

    public Vector2Int GetXY(Vector3 worldPosition)
    {
        return new Vector2Int(Mathf.FloorToInt((worldPosition.x - originPosition.x) / cellSize), Mathf.FloorToInt((worldPosition.y - originPosition.y) / cellSize));
    }
    public void SetValue(int x, int y, TGridObject value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height) // check for valid tile
        {
            gridArray[x, y] = value;
            //textArray[x, y].text = gridArray[x, y].ToString();
        }  
    }
    public void SetValue(Vector3 worldPosition, TGridObject value)  // overloaded to above function, for purpose of ease of calling
    {
        SetValue(GetXY(worldPosition).x, GetXY(worldPosition).y, value);
    }

    public TGridObject getValueAtPos(Vector3 worldPosition)
    {
        return gridArray[(int)(worldPosition.x - originPosition.x), (int)(worldPosition.y - originPosition.y)];
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {

    }

    //public static implicit operator MyGrid<TGridObject>(MyGrid<GameObject> v)
    //{
    //    throw new NotImplementedException();
    //}
}

