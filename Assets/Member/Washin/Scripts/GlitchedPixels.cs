using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchedPixels : MonoBehaviour
{

    float x;
    float y;
    float currentTime;

    [SerializeField] bool autoShuffle;
    [SerializeField] float autoShuffleTime;
    [SerializeField] int numberOfBoxes;
    [SerializeField] GameObject pixelGO;

    private void Start()
    {
        for (int i = 0; i < numberOfBoxes; i++)
        {
            Instantiate(pixelGO, this.transform);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha9)) ShufflePixels();

        if (autoShuffle)
        {
            currentTime += Time.deltaTime / autoShuffleTime;
            if (currentTime >= autoShuffleTime)
            {
                ShufflePixels();
                currentTime = 0;
            }
        }
    }

    private void ShufflePixels()
    {
        foreach (Transform pixel in transform)
        {
            pixel.transform.localScale = getRandomVec();
            pixel.localPosition = new Vector2(GetRandomNumber(-75, 75), GetRandomNumber(-30, 30));
            pixel.GetComponent<GlitchJitter>().SetNewStartingPos();
        }
    }

    private float GetRandomNumber(float min, float max)
    {
        return Random.Range(min, max);
    }

    private Vector2 getRandomVec()
    {
        x = GetRandomNumber(50, 100);
        y = x>= 75 ? GetRandomNumber(x * 0.25f, x * 0.4f) : GetRandomNumber(50, 75);
        float temp = GetRandomNumber(0, 1);
        //Debug.Log(temp);
        return temp >= 0.5 ? new Vector2(x, y) : new Vector2(y, x);
    }
}
