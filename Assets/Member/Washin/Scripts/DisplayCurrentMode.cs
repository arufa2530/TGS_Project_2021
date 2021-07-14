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
    [SerializeField]
    GameObject chat;

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //    ChangeMode(1);

        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //    ChangeMode(2);
    }

    public void ChangeMode(int key)
    {
        if (key == 1)
        {
            Debug.Log("Changed ui to run");
            move.SetActive(true);
            inspect.SetActive(false);
            chat.SetActive(false);
        }
        else if (key == 2)
        {
            inspect.SetActive(true);
            move.SetActive(false);
            chat.SetActive(false);
        }
        else if(key == 3)
        {
            chat.SetActive(true);
            move.SetActive(false);
            inspect.SetActive(false);
        }
    }

}
