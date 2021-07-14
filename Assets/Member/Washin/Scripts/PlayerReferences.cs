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

    private void Start()
    {
        if (thePlayer != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Debug.Log("Start");
        thePlayer = this;

        currentHealth = maxHealth;
        Debug.Log("Player Health = " + currentHealth);

        thePlayer = this;
        GameObject.DontDestroyOnLoad(this.gameObject);

    }

    public static void LostHealth(int value)
    {
        currentHealth -= value;
        theHealthUI.UpdateHealthUI();
        Debug.Log("Current Health = " + currentHealth);
    }
}
