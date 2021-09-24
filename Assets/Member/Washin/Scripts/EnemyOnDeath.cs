using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyOnDeath : MonoBehaviour
{
    [SerializeField] EnemyFadeSpriteOut fadeEnemy;
    [SerializeField] EnemyActions enemyActions;
    [SerializeField] FadeEnemyHealthBarInScript enemyHealth;
    //[SerializeField] EnemyCenterPositionScript enemyCenter;
    //[SerializeField] GameOverScreen changeScene;
    [SerializeField] private float currentTime = 0;
    private float waitTime = 2f;
    [SerializeField] private bool isDead = false;
    [SerializeField] private bool fadeStarted = false;

    // Update is called once per frame
    void Update()
    {
        if(enemyHealth.redBar.value == 0)
        {
            isDead = true;
            if(fadeStarted)
            {
                if (currentTime < waitTime)
                {
                    currentTime += Time.deltaTime / waitTime;
                    return;
                }
                currentTime = 0;
                fadeStarted = false;
                //SceneManager.LoadScene("PaintTestScene");
                SceneManager.LoadScene("DesktopScene");
                //changeScene.ReturnToDesktop();
            }
            enemyHealth.shouldSlideOut = true;
            PlayerShootingScript.instance.StopShooting();
            EnemyCenterPositionScript.instance = null;
            enemyActions.currentActionState = CurrentEnemyAction.Dying;
            fadeEnemy.shouldFadeOutEnemy = true;
            AudioManager.instance.StartFadeOut();
            fadeStarted = true;
        }
    }


}
