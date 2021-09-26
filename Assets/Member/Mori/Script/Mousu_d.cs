using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mousu_d : MonoBehaviour
{
    enum ONOFF
    {
        on,
        off,
    }

    [SerializeField]ONOFF onf;

    private void Awake()
    {
        switch(onf)
        {
            case ONOFF.on:
                Cursor.visible = true;
                break;
            case ONOFF.off:
                Cursor.visible = false;
                break;

        }
    }
}
