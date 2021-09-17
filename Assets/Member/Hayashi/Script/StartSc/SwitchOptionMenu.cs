using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SwitchOptionMenu : MonoBehaviour
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
        GameObject.Find("MenuController").GetComponent<MenuController>().OptionCoroutine();
        IsSwitch = false;
    }
}
