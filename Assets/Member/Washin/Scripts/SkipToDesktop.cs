using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipToDesktop : MonoBehaviour
{
    [SerializeField] ChangeScene changeScene;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            changeScene.LoadNextScene(7);
        }
    }

}
