using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReferences : MonoBehaviour
{

    public static int currentHealth;
    public static int maxHealth = 4;
    public static PlayerReferences thePlayer;
    public static PlayerHealthScript theHealthUI;
    public static GameOverScreen theGameIsOver;
    public static bool finishSlowSpam = false;
    public static PlayerMovement playerMovement;
    public static int battleStageCount;
    public static bool iFramesActive = false;

    private void Awake()
    {
        if (thePlayer != null)
        {
            Destroy(this.gameObject);
            return;
        }
        //Debug.Log("Start");
        thePlayer = this;

        currentHealth = maxHealth;
        //Debug.Log("Player Health = " + currentHealth);

        thePlayer = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    public static void LostHealth(int value)
    {
        if (AreIFramesActive()) return;
        currentHealth -= value;
        theHealthUI.UpdateHealthUI();
        SetIFrames(true);
        //Debug.Log("Current Health = " + currentHealth);
    }

    public static void PlayerEnteredBattleStage()
    {
        battleStageCount++;
    }

    public static bool AreIFramesActive()
    {
        return iFramesActive;
    }

    public static void SetIFrames(bool _bool)
    {
        iFramesActive = _bool;
    }
}
