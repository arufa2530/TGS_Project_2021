using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeToNextScene : MonoBehaviour
{
    [SerializeField] SpriteRenderer overlay;
    float fadeTime = 1;
    float currentTime;
    [SerializeField] Color color = new Color(0, 0, 0, 0);
    [SerializeField] bool dontLoadScene;

    private void Update()
    {
        if (currentTime < 1)
        {
            currentTime += Time.deltaTime / fadeTime;
            color.a = currentTime;
            overlay.color = color;
        }
        else
        {
            if (dontLoadScene) return;

            SceneManager.LoadScene("Test_End");
        }
    }

    public void SetFadeTime(float timeToFade)
    {
        fadeTime = timeToFade;
    }
}
