using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMenu : MonoBehaviour
{
    public bool IsSwitch = false;

    public void OnMenu()
    {
        this.gameObject.SetActive(true);
    }

    public void OffMenu()
    {
        this.gameObject.SetActive(false);
    }

    private void OnMouseEnter()
    {
        IsSwitch = true;
    }

    private void OnMouseExit()
    {
        IsSwitch = false;
    }
}
