using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePopUpScript : MonoBehaviour
{
    private void OnMouseDown()
    {
        Destroy(transform.parent.gameObject);
    }
}
