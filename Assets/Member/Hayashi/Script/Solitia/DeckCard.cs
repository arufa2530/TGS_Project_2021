using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckCard : MonoBehaviour
{
    [SerializeField] SolitiaController Controller;
    private void OnMouseDown()
    {
        Controller.CreateCard();
    }
}
