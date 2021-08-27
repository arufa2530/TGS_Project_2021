using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    List<string> listOfTags = new List<string>();
    bool flag = false;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        foreach (string tag in listOfTags)
            if (collision.gameObject.CompareTag(tag))
                flag = true;
    }
}
