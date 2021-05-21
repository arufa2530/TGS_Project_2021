using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution_Change : MonoBehaviour
{
    private void Awake()
    {
        Screen.SetResolution(640,480,true);
    }
}
