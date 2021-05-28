using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{
    [SerializeField]
    private int currentHealth;
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    DestroyPlayerScript _player;
    [SerializeField]
    GameOverScreen _gameOverScreen;


    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            _player.NoHealthRemaining();
            //Instantiate(_gameOverScreen,transform.position,Quaternion.identity);
            _gameOverScreen.GameOverTrigger();
            Destroy(this.gameObject);
        }

        if (Input.GetKeyDown(KeyCode.KeypadMinus))
            TookDamage();
    }

    public void TookDamage()
    {
        currentHealth--;
        Destroy(this.GetComponent<Transform>().GetChild(currentHealth).gameObject);
    }
}
