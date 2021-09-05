using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawZoneSc : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        IsCollision();
    }

    void IsCollision()
    {
        if (this.transform.childCount > 0)
        {
            for (int i = 0; i < this.transform.childCount - 1; i++)
            {
                GameObject child = this.transform.GetChild(i).gameObject;
                child.GetComponent<BoxCollider2D>().enabled = false;
            }
            this.transform.GetChild(transform.childCount - 1).gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
