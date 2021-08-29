using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFadeSpriteOut : MonoBehaviour
{

    [SerializeField] public bool shouldFadeOutEnemy = false;
    [SerializeField] public bool shouldFadeInEnemy = true;
    [SerializeField] SpriteRenderer enemySprite;
    [SerializeField] private float fadeOutTime;
    [SerializeField] private float fadeInTime;
    [SerializeField] private float currentTime = 0;
    [SerializeField] private float waitTime = 1;
    [SerializeField] private bool firstWaitDone = false;
    Color fadingOutColor;
    Color fadingInColor;

    private void Start()
    {
        fadingOutColor = enemySprite.color;
        fadingInColor = enemySprite.color;
        fadingInColor.a = 0;
        enemySprite.color = fadingInColor;
    }

    void Update()
    {
        if(!firstWaitDone)
        {
            currentTime += Time.deltaTime / waitTime;
            if (currentTime > waitTime) firstWaitDone = true;
            return;
        }

        if (shouldFadeOutEnemy)
        {
            fadingOutColor.a -= Time.deltaTime / fadeOutTime;
            enemySprite.color = fadingOutColor;
            if (fadingOutColor.a == 0)
            {
                shouldFadeOutEnemy = false;
                this.enabled = false;
            }
            return;
        }
        if (shouldFadeInEnemy)
        {
            fadingInColor.a += Time.deltaTime / fadeInTime;
            enemySprite.color = fadingInColor;
            if (fadingInColor.a == 1)
            {
                shouldFadeInEnemy = false;
            }
            return;
        }
    }
}
