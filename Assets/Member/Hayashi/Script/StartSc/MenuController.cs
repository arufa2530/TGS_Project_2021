using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject[] Menu;
    [SerializeField] GameObject[] Window;
    [SerializeField] Button[] MenuButton;
    [SerializeField] Button[] ItemMenuButton;

    bool[] IsMenu = new bool[2];
    bool[] IsWindow = new bool[3];
    bool[] IsButton = new bool[3];
    bool[] IsItemButton = new bool[4];

    enum MenuNum
    {
        StartMenu,
        ItemMenu
    }

    enum WindowNum
    {
        ItemWindow,
        OptionWindow,
        GalleryWindow
    }

    enum ButtonNum
    {
        ItemButton,
        OptionButton,
        GalleryButton
    }

    private void Update()
    {
        CheckSwitch();
        SwitchButton();
        SwitchItemButton();
    }

    IEnumerator BreakInItemTime()
    {
        IsItemButton = new bool[] { false, false, false, false,};
        var times = 0f;
        while (times < 0.5f)
        {
            times += Time.deltaTime;
            if (IsButton[(int)ButtonNum.ItemButton] || IsItemButton.Any(Is => Is == true))
            {
                yield break;
            }
            yield return null;
        }
        Menu[(int)MenuNum.ItemMenu].gameObject.SetActive(false);
        yield break;
    }

    IEnumerator BreakInOptionTime()
    {
        IsWindow[(int)WindowNum.OptionWindow] = false;
        var times = 0f;
        while (times < 0.5f)
        {
            times += Time.deltaTime;
            if (IsButton[(int)ButtonNum.OptionButton] || IsWindow[(int)WindowNum.OptionWindow])
            {
                yield break;
            }
            yield return null;
        }
        Window[(int)WindowNum.OptionWindow].gameObject.SetActive(false);
        yield break;
    }

    IEnumerator ItemMenuTime()
    {
        var times = 0f;
        while (times < 0.5f)
        {
            times += Time.deltaTime;
            if (IsItemButton.Any(Is => Is == true))
            {
                yield break;
            }
            yield return null;
        }
        Menu[(int)MenuNum.ItemMenu].gameObject.SetActive(false);
        yield break;
    }

    IEnumerator OptionMenuTime()
    {
        var times = 0f;
        while (times < 0.5f)
        {
            times += Time.deltaTime;
            if (IsWindow[(int)WindowNum.OptionWindow])
            {
                yield break;
            }
            yield return null;
        }
        Window[(int)WindowNum.OptionWindow].gameObject.SetActive(false);
        yield break;
    }

    public void Coroutine()
    {
        StartCoroutine(ItemMenuTime());
    }

    public void Coroutine2()
    {
        StartCoroutine(BreakInItemTime());
    }

    public void OptionCoroutine()
    {
        StartCoroutine(OptionMenuTime());
    }

    public void BreakOptionCoroutine()
    {
        StartCoroutine(BreakInOptionTime());
    }

    public void CheckSwitch()
    {
        for (int i = 0; i < IsButton.Length; i++)
        {
            if (i == (int)ButtonNum.ItemButton)
                IsButton[i] = MenuButton[i].GetComponent<SwitchItemButton>().IsSwitch;
            else if (i == (int)ButtonNum.OptionButton)
                IsButton[i] = MenuButton[i].GetComponent<SwitchOptionMenu>().IsSwitch;
            else
                IsButton[i] = MenuButton[i].GetComponent<SwitchButton>().IsSwitch;
        }
        for (int i = 0; i < IsItemButton.Length; i++)
        {
            IsItemButton[i] = ItemMenuButton[i].GetComponent<SwitchInItemButton>().IsSwitch;
        }

        for (int i = 0; i < IsWindow.Length; i++)
        {
            if (i == (int)WindowNum.OptionWindow)
                IsWindow[i] = Window[i].GetComponent<SwitchInOptionMenu>().IsSwitch;
            else
                IsWindow[i] = Window[i].GetComponent<SwitchMenu>().IsSwitch;
        }
    }

    void SwitchButton()
    {
        for (int i = 0; i < IsButton.Length; i++)
        {
            if (i == (int)ButtonNum.ItemButton)
            {
                if (IsButton[i])
                {
                    MenuButton[i].GetComponent<SwitchItemButton>().OnButton();
                    Menu[(int)MenuNum.ItemMenu].gameObject.SetActive(true);
                }
                else if (Menu[(int)MenuNum.ItemMenu].gameObject.activeSelf && !IsButton[(int)ButtonNum.OptionButton] && !IsButton[(int)ButtonNum.GalleryButton])
                {
                    MenuButton[i].GetComponent<SwitchItemButton>().OnButton();
                }
                else
                {
                    MenuButton[i].GetComponent<SwitchItemButton>().OffButton();
                }
            }
            else if (i == (int)ButtonNum.OptionButton)
            {
                if (IsButton[i])
                {
                    MenuButton[i].GetComponent<SwitchOptionMenu>().OnButton();
                    Window[(int)WindowNum.OptionWindow].gameObject.SetActive(true);
                }
                else
                {
                    MenuButton[i].GetComponent<SwitchOptionMenu>().OffButton();
                }
            }
            else
            {
                if (IsButton[i])
                {
                    MenuButton[i].GetComponent<SwitchButton>().OnButton();
                }
                else
                {
                    MenuButton[i].GetComponent<SwitchButton>().OffButton();
                }
            }
        }
    }

    void SwitchItemButton()
    {
        for (int i = 0; i < IsItemButton.Length; i++)
        {
            if (IsItemButton[i])
            {
                ItemMenuButton[i].GetComponent<SwitchInItemButton>().OnButton();
            }
            else
            {
                ItemMenuButton[i].GetComponent<SwitchInItemButton>().OffButton();
            }
        }
    }

    void SwitchWindow()
    {

    }

    public void OnOffMenu()
    {
        if (Menu[(int)MenuNum.StartMenu].activeSelf)
        {
            Menu[(int)MenuNum.StartMenu].SetActive(false);
            GameObject.Find("StartButton").GetComponent<SwitchButton>().OffButton();
        }
        else
        {
            Menu[(int)MenuNum.StartMenu].SetActive(true);
            GameObject.Find("StartButton").GetComponent<SwitchButton>().OnButton();
        }
    }
}
