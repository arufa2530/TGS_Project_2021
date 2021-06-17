using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMenu : MonoBehaviour
{
    public void OnMenu()
    {
        this.gameObject.SetActive(true);
    }

    public void OffMenu()
    {
        this.gameObject.SetActive(false);
    }
}
