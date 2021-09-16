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

    private void Start()
    {
        //StartCoroutine(StartPlayerShoot());
    }

    public void TakeDamage(int damageToTake)
    {
        hpBar.value -= damageToTake;
    }

    IEnumerator StartPlayerShoot()
    {
        yield return new WaitForSeconds(3f);
        //PlayerShootingScript.instance.ShouldBeShooting = true;
        PlayerShootingScript.instance.AllowShooting();
    }

}
