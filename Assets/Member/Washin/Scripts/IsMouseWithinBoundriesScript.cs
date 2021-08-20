using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsMouseWithinBoundriesScript : MonoBehaviour
{

    public bool isWithinDrawBoundries;

    private void OnMouseEnter()
    {
        Debug.Log("MouseIn");
        isWithinDrawBoundries = true;
    }

    private void OnMouseExit()
    {
        Debug.Log("MouseOut");
        isWithinDrawBoundries = false;
    }

    public bool isMouseInsideDrawBoundries()
    {
        return isWithinDrawBoundries;
    }
}
