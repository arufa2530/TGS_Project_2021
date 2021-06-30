using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShouldDisplaySomethingScript : MonoBehaviour
{
    [SerializeField]
    public bool shouldDisplaySomethingOnScreen;
    [SerializeField]
    GameObject thingToSpawn;
    [SerializeField] TextMeshProUGUI text;

    private void Start()
    {
        if(shouldDisplaySomethingOnScreen)
        {
            text.text = "";
            SpawnSomethingOnDisplay(thingToSpawn);
        }
    }

    public void SpawnSomethingOnDisplay(GameObject prefab)
    {
        GameObject thingToDisplay = Instantiate(prefab);
    }
}
