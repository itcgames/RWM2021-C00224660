using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Author: Josh Browne

public class TileMapObject :  MonoBehaviour
{
    public GameObject tileGameObject;
    public Canvas canvas;
    private float m_x;
    private float m_y;
    private float cellSize;
    private CanvasRenderer canvasRenderer;
    Image tileImage;
    public TileMapObject(int t_x, int t_y, float cellSize)
    {
        tileGameObject = new GameObject("TileGameObject");
        this.cellSize = cellSize;
        canvasRenderer = tileGameObject.AddComponent<CanvasRenderer>();
        tileImage = tileGameObject.AddComponent<Image>(); //Add the Image Component script
        canvas = tileGameObject.AddComponent<Canvas>();
        tileGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(cellSize, cellSize);
        canvasRenderer.SetColor(new Color(1f, 1f, 1f, 0f));// is about 100 % transparent(Cant be seen at all, but still active)
    }

    public void SetTileMapSprite(Sprite t_sprite)
    {
        tileImage.sprite = t_sprite; //Set the Sprite of the Image Component on the new GameObject
        canvasRenderer.SetColor(new Color(1f, 1f, 1f, 1f)); //is a normal sprite
    }

    public void SetXY(int x, int y)
    {
        m_x = x;
        m_y = y;
        tileGameObject.transform.localPosition = new Vector3(m_x + (cellSize / 2), m_y + (cellSize / 2));
    }
}
