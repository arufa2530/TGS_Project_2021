using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectOnAlphaZeroScript : MonoBehaviour
{
    float currentAlpha;
    Color objectAlpha;
    int timeToFade = 1;
    float time = 0;
    private void Awake()
    {
        currentAlpha = GetComponent<SpriteRenderer>().color.a;
        //currentAlpha = 1;
        objectAlpha = this.gameObject.GetComponent<SpriteRenderer>().color;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.fixedDeltaTime;

        objectAlpha = new Color(1, 1, 1, Mathf.SmoothStep(objectAlpha.a, 0, time / timeToFade));
        this.gameObject.GetComponent<SpriteRenderer>().color = objectAlpha;

        if (objectAlpha.a < 0.01f) Destroy(this.gameObject);
    }
}
