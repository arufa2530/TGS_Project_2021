using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpHPDisplay : MonoBehaviour
{
    [SerializeField] Image currentHP;

    public void UpdateHPDisplay(float remainingHP)
    {
        currentHP.rectTransform.localScale = new Vector3(remainingHP, 1, 1);
    }
}
