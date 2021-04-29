using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{
    [SerializeField]
    static GameOverScreen _gameOverScreen;
    public Transform[] healthIcon;
    private void Start()
    {
        if (PlayerReferences.theHealthUI != null)
        {
            Destroy(transform.parent.gameObject);
            return;
        }

        PlayerReferences.theHealthUI = this;
        healthIcon = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            healthIcon[i] = transform.GetChild(i);
        GameObject.DontDestroyOnLoad(transform.parent.gameObject);
    }

    public void UpdateHealthUI()
    {
        healthIcon[PlayerReferences.currentHealth].gameObject.SetActive(false);
        if (PlayerReferences.currentHealth < 1)
            PlayerReferences.theGameIsOver.GameOverTrigger();
    }
}
