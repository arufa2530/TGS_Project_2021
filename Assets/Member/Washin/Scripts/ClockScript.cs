using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClockScript : MonoBehaviour
{
    [SerializeField]
    TMP_Text textBox;
    private void Update()
    {
        //Debug.Log(DateTime.Now);
        var time = DateTime.Now;
        textBox.text = time.ToShortTimeString();

    }
}
