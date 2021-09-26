using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brush : MonoBehaviour
{
    [SerializeField] SolitiaController controller;
    [SerializeField] GameObject BrushLine;
    GameObject fileicon;
    FileIcon fileIcon_c;

    private void Awake()
    {
        fileicon = GameObject.Find("FileIcon_a");
        fileIcon_c = fileicon.GetComponent<FileIcon>();
    }

    private void Update()
    {
        if (BrushLine.transform.childCount > 0)
        {
            this.GetComponent<CapsuleCollider2D>().enabled = false;
        }
        else
        {
            this.GetComponent<CapsuleCollider2D>().enabled = true;
        }
    }

    private void OnMouseDown()
    {
        if(fileicon != null)
        {
            fileIcon_c.d = false;
            fileIcon_c.c = true;
        }
        controller.DestroyWindow();
    }
}
