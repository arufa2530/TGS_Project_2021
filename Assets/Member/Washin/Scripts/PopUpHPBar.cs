using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpHPBar : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] float currentHealth;
    [SerializeField] GameObject popUpHealthBar;
    [SerializeField] GameObject trackingPoint;

    GameObject tempHealthBar;
    PopUpHPDisplay hpDisplay;

    private void Start()
    {
        tempHealthBar = Instantiate(popUpHealthBar, PopUpCanvasRef.canvas.transform);
        hpDisplay = tempHealthBar.GetComponent<PopUpHPDisplay>();
        currentHealth = maxHealth;
    }

    private void Update()
    {
        tempHealthBar.transform.position = trackingPoint.transform.position;
    }

    public void DamagePopUpWindow()
    {
        currentHealth -= 0.5f;
        hpDisplay.UpdateHPDisplay(currentHealth / maxHealth);
        if (currentHealth <= 0)
        {
            Destroy(tempHealthBar.gameObject);
            Destroy(this.gameObject);
        }
    }




}
