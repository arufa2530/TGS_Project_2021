using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemMeneController : MonoBehaviour
{
    public int FirewallInvader = 0, Vaccine = 0, Brush = 0;

    [SerializeField] Text[] ItemButton = new Text[4];
    // Start is called before the first frame update
    void Start()
    {
        FirewallInvader++;
    }

    // Update is called once per frame
    void Update()
    {
        ItemDraw();
    }

    private void ItemDraw()
    {
        int ItemTotal = FirewallInvader + Vaccine + Brush;
        for (int i = 0; i < FirewallInvader; i++)
        {
            if (i < 4)
            {
                ItemButton[i].text = "Firewall Invader";
            }
        }
        for (int i = FirewallInvader; i < FirewallInvader + Vaccine; i++)
        {
            if (i < 4)
            {
                ItemButton[i].text = "特効ワクチン弾";
            }
        }
        for (int i = FirewallInvader + Vaccine; i < ItemTotal; i++)
        {
            if (i < 4)
            {
                ItemButton[i].text = "ブラシ";
            }
        }
        for (int i = ItemTotal; i < 4; i++)
        {
            ItemButton[i].text = "No Data";
        }
    }
}
