using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnDeath : MonoBehaviour
{
    [SerializeField] EnemyFadeSpriteOut fadeEnemy;
    [SerializeField] EnemyActions enemyActions;
    [SerializeField] FadeEnemyHealthBarInScript enemyHealth;
    [SerializeField] GameOverScreen changeScene;
    [SerializeField] private float currentTime = 0;
    private float waitTime = 2f;
    [SerializeField] private bool fadeStarted = false;

    // Update is called once per frame
    void Update()
    {
        if(enemyHealth.redBar.value == 0)
        {
            if(fadeStarted)
            {
                if (currentTime < waitTime)
                {
                    currentTime += Time.deltaTime / waitTime;
                    return;
                }
                changeScene.ReturnToDesktop();
            }
            enemyHealth.shouldSlideOut = true;
            PlayerShootingScript.instance.StopShooting();
            enemyActions.currentActionState = CurrentEnemyAction.Dying;
            fadeEnemy.shouldFadeOutEnemy = true;
            AudioManager.instance.StartFadeOut();
            fadeStarted = true;
            
        }
    }


}
