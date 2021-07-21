using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskBarAppController : MonoBehaviour
{
    GameObject AppController;
    // Start is called before the first frame update
    void Start()
    {
        AppController = GameObject.Find("AppController");
        this.transform.parent = AppController.transform;
    }
}
