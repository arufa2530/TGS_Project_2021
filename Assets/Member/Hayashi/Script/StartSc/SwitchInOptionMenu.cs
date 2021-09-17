using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchInOptionMenu : MonoBehaviour
{
    public bool IsSwitch = false;

    private void Update()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManagerSc>().SeVolume = this.transform.Find("SESlider").GetComponent<Slider>().value;
        GameObject.Find("SoundManager").GetComponent<SoundManagerSc>().BgmVolume = this.transform.Find("BGMSlider").GetComponent<Slider>().value;
    }

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
        GameObject.Find("MenuController").GetComponent<MenuController>().CheckSwitch();
        GameObject.Find("MenuController").GetComponent<MenuController>().BreakOptionCoroutine();
        IsSwitch = false;
    }
}
