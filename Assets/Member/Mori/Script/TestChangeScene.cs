using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChangeScene : MonoBehaviour
{
    [SerializeField] GameObject internet;
    DoubleClickedChecker doubleC;

    private void Awake()
    {
        doubleC = internet.GetComponent<DoubleClickedChecker>();
        doubleC.OldChangeScene();
    }
}
