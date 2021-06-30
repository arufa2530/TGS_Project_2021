using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningBannerScript : MonoBehaviour
{
    [SerializeField] float startDelay;
    [SerializeField] float flashTime;
    [SerializeField] GameObject textToFlash;
    bool isActive = true;

    private void Start()
    {
        InvokeRepeating("FlashText", startDelay, flashTime);
    }

    public void FlashText()
    {
        Debug.Log("Tick");
        textToFlash.SetActive(isActive);
        isActive = !isActive;
        
    }
}
