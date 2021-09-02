using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineZoneSc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.childCount > 0)
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            this.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
