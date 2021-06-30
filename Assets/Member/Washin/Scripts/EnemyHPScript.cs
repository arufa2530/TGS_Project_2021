using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPScript : MonoBehaviour
{
    [SerializeField] Slider hpBar;

    public static EnemyHPScript instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        return;
    }

    public void TakeDamage(int damageToTake)
    {
        hpBar.value -= damageToTake;
    }

}
