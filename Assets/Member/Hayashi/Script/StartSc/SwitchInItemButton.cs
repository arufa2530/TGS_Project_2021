using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchInItemButton : MonoBehaviour
{
    [SerializeField] Sprite[] MySprite;

    public bool IsSwitch = false;

    public void OnButton()
    {
        this.GetComponent<Image>().sprite = MySprite[1];
    }

    public void OffButton()
    {
        this.GetComponent<Image>().sprite = MySprite[0];
    }

    private void OnMouseEnter()
    {
        IsSwitch = true;
    }

    private void OnMouseExit()
    {
        GameObject.Find("MenuController").GetComponent<MenuController>().CheckSwitch();
        GameObject.Find("MenuController").GetComponent<MenuController>().Coroutine2();
        IsSwitch = false;
    }
}
