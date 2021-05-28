using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAnimationScript : MonoBehaviour
{
    [SerializeField]
    GameObject[] stopTheseAnimations;

    public void StopAnimations()
    {
        foreach (GameObject animations in stopTheseAnimations)
        {
            Animator ani = animations.GetComponent<Animator>();
            ani.enabled = false;
        }
    }
}
