using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Author: Josh Browne

public class SpriteSelection
{
    public GameObject[] spriteGameObjects;
    public Sprite[] spriteArray;
    public Canvas parentPanel;
    public GameObject selectionPanelGameObject;
    private CanvasRenderer canvasRenderer;
    public GameObject imageContainer;
    public GameObject scrollArea;

    //Constructor
    public SpriteSelection(float x, float y, float panelWidth, float panelHeight, float cellSize)
    {
        // make game obj and sprite renderer
        selectionPanelGameObject = new GameObject("SelectionPanelGameObject");
        imageContainer = new GameObject("ImageContainer");
        scrollArea = new GameObject("ScrollArea");
        imageContainer.AddComponent<RectTransform>();
        imageContainer.GetComponent<RectTransform>().rect.size.Set(1000, 1000);
        
        imageContainer.transform.parent = scrollArea.transform;
        scrollArea.transform.parent = selectionPanelGameObject.transform;
        scrollArea.AddComponent<Image>();
        scrollArea.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f); // transparnt
        scrollArea.AddComponent<ScrollRect>();
        scrollArea.AddComponent<Mask>();
        //scrollArea.AddComponent<ScrollRect>().content = imageContainer.GetComponent<RectTransform>();

        imageContainer.transform.SetParent(selectionPanelGameObject.transform);
        selectionPanelGameObject.transform.position = new Vector2(x, y);
        selectionPanelGameObject.AddComponent<CanvasRenderer>();
        canvasRenderer = selectionPanelGameObject.GetComponent<CanvasRenderer>();
        canvasRenderer.SetColor(Color.black);

        // load sprite assets
        spriteArray = Resources.LoadAll<Sprite>("Sprites/");
        spriteGameObjects = new GameObject[spriteArray.Length];

        // create & set rect dimensions
        parentPanel = selectionPanelGameObject.AddComponent<Canvas>();
        selectionPanelGameObject.GetComponent<RectTransform>().sizeDelta.Set(panelWidth, panelHeight);

        int count = 0;
        //create the image objects and set parent to panel
        foreach (Sprite sprite in spriteArray)
        {
            //sprite.bounds.size.Set(1, 1, 1);
            GameObject NewObj = new GameObject("Sprite Selection Item"); //Create the GameObject
            NewObj.transform.SetParent(imageContainer.transform);
            NewObj.AddComponent<BoxCollider2D>();
            NewObj.transform.position = new Vector2(x + 1.25f, cellSize * count + .5f * count + 2);

            Image NewImage = NewObj.AddComponent<Image>(); //Add the Image Component script
            NewImage.sprite = sprite; //Set the Sprite of the Image Component on the new GameObject
            NewObj.GetComponent<RectTransform>().SetParent(selectionPanelGameObject.GetComponent<RectTransform>()); //Assign the newly created Image GameObject as a Child of the Parent Panel.
            NewObj.GetComponent<RectTransform>().sizeDelta = new Vector2(cellSize, cellSize);
            spriteGameObjects[count] = NewObj; // push to array for later use
            count++; // increment
        }

    }

    public Sprite checkMouseClickOnSpriteSelection(Vector3 t_mousePos)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = t_mousePos;
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                Vector3 clickedSpritePos = hit.collider.gameObject.transform.position;
                foreach (GameObject gameObj in spriteGameObjects)
                {
                    if (gameObj.transform.position == clickedSpritePos)
                    {
                        return gameObj.GetComponent<Image>().sprite;
                    }
                }
            }
        }
        return null;
    }
}
