using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Erase : MonoBehaviour
{
    //https://docs.unity3d.com/ScriptReference/RaycastHit-textureCoord.html
    //https://answers.unity.com/questions/687116/what-is-the-easiest-way-to-convert-raycasthit2d-to.html

    Texture2D drawnImage;
    Color[] pixelColors;
    SpriteRenderer spriteRenderer;
    [SerializeField] int brushSize;
    [SerializeField] bool isDrawing;

    int checkColorCount;

    Vector2Int lastBrushPos;

    RaycastHit2D hit;

    DoubleClickedChecker doubleClickedChecker;
    public bool canErase = false;

    private void Start()
    {
        doubleClickedChecker = GetComponentInChildren<DoubleClickedChecker>();
        doubleClickedChecker.CanBeClicked(false);
        spriteRenderer = GetComponent<SpriteRenderer>();
        var tempTexture = spriteRenderer.sprite.texture;

        //create copy of source image
        drawnImage = new Texture2D(tempTexture.width, tempTexture.height);
        drawnImage.filterMode = FilterMode.Point;
        drawnImage.wrapMode = TextureWrapMode.Clamp;
        pixelColors = tempTexture.GetPixels();
        drawnImage.SetPixels(pixelColors);
        drawnImage.Apply();

        //set copy as source image
        spriteRenderer.sprite = Sprite.Create(drawnImage, spriteRenderer.sprite.rect, new Vector2(0.5f, 0.5f));
    }

    private void Update()
    {
        DebugToggleErase();

        if (canErase && Input.GetMouseButton(0))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                int width = drawnImage.width;
                int height = drawnImage.height;

                var mousePos = hit.point - (Vector2)hit.collider.bounds.min;
                mousePos.x = (width / hit.collider.bounds.size.x) * mousePos.x;
                mousePos.y = (height / hit.collider.bounds.size.y) * mousePos.y;
                Vector2Int stroke = new Vector2Int((int)mousePos.x, (int)mousePos.y);

                Vector2Int pointStart = new Vector2Int();
                Vector2Int pointEnd = new Vector2Int();

                if (!isDrawing)
                    lastBrushPos = stroke;

                pointStart.x = Mathf.Clamp(Mathf.Min(stroke.x, lastBrushPos.x) - brushSize, 0, width);
                pointStart.y = Mathf.Clamp(Mathf.Min(stroke.y, lastBrushPos.y) - brushSize, 0, height);

                pointEnd.x = Mathf.Clamp(Mathf.Max(stroke.x, lastBrushPos.x) + brushSize, 0, width);
                pointEnd.y = Mathf.Clamp(Mathf.Max(stroke.y, lastBrushPos.y) + brushSize, 0, height);

                Vector2 directionVec = stroke - lastBrushPos;

                //foreach pixel within path mark pixels to be changed
                for (int x = pointStart.x; x < pointEnd.x; x++)
                {
                    for (int y = pointStart.y; y < pointEnd.y; y++)
                    {
                        Vector2 pixelPos = new Vector2(x, y);
                        Vector2 linePos = stroke;

                        if (isDrawing)
                        {
                            float dotProduct = Vector2.Dot(pixelPos - lastBrushPos, directionVec) / directionVec.sqrMagnitude;
                            dotProduct = Mathf.Clamp01(dotProduct);
                            linePos = Vector2.Lerp(lastBrushPos, stroke, dotProduct);
                        }
                        if ((pixelPos - linePos).sqrMagnitude <= brushSize * brushSize)
                            pixelColors[x + y * width] = Color.clear;
                    }
                }

                lastBrushPos = stroke;
                drawnImage.SetPixels(pixelColors);
                drawnImage.Apply();
                spriteRenderer.sprite = Sprite.Create(drawnImage, spriteRenderer.sprite.rect, new Vector2(0.5f, 0.5f));

                isDrawing = true;
            }
        }
        else
            isDrawing = false;

        if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(CheckColors());

            if(checkColorCount > pixelColors.Length/4f)
            {
                doubleClickedChecker.CanBeClicked(true);
            }
        }
    }

    public void CanErase(bool _canErase)
    {
        canErase = _canErase;
    }

    void DebugToggleErase()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            CanErase(!canErase);
            Debug.Log("canErase is set to" + canErase);
        }
    }

    IEnumerator CheckColors()
    {
        foreach (Color color in pixelColors)
        {
            if (color == Color.clear) checkColorCount++;
        }
        yield return null;
    }
}

