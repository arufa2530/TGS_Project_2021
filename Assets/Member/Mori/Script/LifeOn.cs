using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeOn : MonoBehaviour
{
    [SerializeField]
    GameObject life;

    // Start is called before the first frame update
    void Start()
    {
        //life = GameObject.Find("PlayerHolderNew");
        PlayerReferences.battleStageCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
