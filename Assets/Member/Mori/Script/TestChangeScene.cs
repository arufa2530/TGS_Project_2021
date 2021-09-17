using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChangeScene : MonoBehaviour
{
    [SerializeField] GameObject internet;
    ChangeScene doubleC;


    private void Start()
    {
        doubleC = internet.GetComponent<ChangeScene>();
        doubleC.LoadNextScene(100);
    }
}

