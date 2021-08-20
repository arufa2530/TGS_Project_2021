using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;

public class PaintScript : MonoBehaviour
{
    [SerializeField]
    GameObject defaultBrush;
    [SerializeField]
    Transform drawSpace;
    [SerializeField]
    Transform brushHolder;
    [SerializeField]
    RenderTexture renderedTexture;
    int imageCount = 0;
    [HideInInspector]
    public Vector3 brushScaleValue;

    [SerializeField]
    Slider brushScaleSlider;

    [SerializeField]
    IsMouseWithinBoundriesScript _IsMouseWithinBoundriesScript;

    [SerializeField]
    Sprite stockImage;
    Texture2D[] images;
    int x, y;

    GameObject displayForCurrentBrush;
    Image brushColorRenderer;
    Color currentSelectedColor = Color.yellow;
    RaycastHit2D hitForBrush;

    private void Start()
    {
        displayForCurrentBrush = Instantiate(defaultBrush, brushHolder);
        brushColorRenderer = displayForCurrentBrush.GetComponent<Image>();
    }


    private void Update()
    {
        if (!_IsMouseWithinBoundriesScript.isMouseInsideDrawBoundries())
        {
            brushColorRenderer.color = Color.red;
            displayForCurrentBrush.transform.localPosition = Vector3.zero;
        }
        else
        {
            brushColorRenderer.color = currentSelectedColor;
            hitForBrush = MousePositionFromRay();
            displayForCurrentBrush.transform.position = hitForBrush.point;
            Draw();
        }
        displayForCurrentBrush.transform.localScale = ChangeBrushSize();
    }



    private void Draw()
    {
        if (Input.GetMouseButton(0))
        {
            //RaycastHit2D hit = MousePositionFromRay();

            GameObject brushStroke = Instantiate(defaultBrush, hitForBrush.point, Quaternion.identity, drawSpace);
            brushStroke.transform.localScale = ChangeBrushSize();
        }
    }

    private static RaycastHit2D MousePositionFromRay()
    {
        Vector3 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(ray.x, ray.y), Vector2.zero);
        return hit;
    }

    public void Save()
    {

        StartCoroutine(SaveRenderTextureToPng());


    }


    private IEnumerator SaveRenderTextureToPng()
    {
        DisplayPreviewBrush(false);

        yield return new WaitForEndOfFrame();

        RenderTexture.active = renderedTexture;

        var drawnImage = new Texture2D(renderedTexture.width, renderedTexture.height);
        drawnImage.ReadPixels(new Rect(0, 0, renderedTexture.width, renderedTexture.height), 0, 0);
        drawnImage.Apply();

        var drawningToSave = drawnImage.EncodeToPNG();
        //File.WriteAllBytes(Application.dataPath + "/Member/Washin/Images/PaintedImages/Image-" + System.Guid.NewGuid() + ".png", drawningToSave);
        File.WriteAllBytes(Application.dataPath + "/Member/Washin/Images/PaintedImages/Image-" + ++imageCount + ".png", drawningToSave);

        DisplayPreviewBrush(true);
    }

    public void CompareTwoDrawings()
    {
        images = new Texture2D[2];
        images[0] = new Texture2D(1, 1);
        images[1] = new Texture2D(1, 1);

        images[0].LoadImage(File.ReadAllBytes(Application.dataPath + "/Member/Washin/Images/PaintedImages/Image-" + imageCount + ".png"));
        //images[1].LoadImage(File.ReadAllBytes(AssetDatabase.GetAssetPath(stockImage)));


        for (x = images[0].width; x > 0; x--)
        {
            for (y = images[0].height; y > 0; y--)
            {

            }
        }
    }

    public Vector3 ChangeBrushSize()
    {
        float tempScale = brushScaleSlider.value;
        brushScaleValue = new Vector3(tempScale, tempScale, tempScale);
        return brushScaleValue;
    }

    public void DisplayPreviewBrush(bool showBrush)
    {
        if (showBrush)
            displayForCurrentBrush.SetActive(true);
        else
            displayForCurrentBrush.SetActive(false);
    }


}
