using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCurrentMode : MonoBehaviour
{

    int currentMode;
    [SerializeField]
    GameObject inspect;
    [SerializeField]
    GameObject move;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            ChangeMode(1);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            ChangeMode(2);
    }

    public void ChangeMode(int key)
    {
        if (key == 1)
        {
            inspect.SetActive(false);
            move.SetActive(true);
        }
        else if (key == 2)
        {
            move.SetActive(false);
            inspect.SetActive(true);
        }
    }


}
