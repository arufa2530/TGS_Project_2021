using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_On : MonoBehaviour
{
    [SerializeField] GameObject cont;
    [SerializeField] GameObject exec;
    Conversatio_UI conUi;

    private void Awake()
    {
        conUi = cont.GetComponent<Conversatio_UI>();
        exec.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(conUi.c)
        {
            exec.SetActive(true);
            cont.SetActive(false);
        }
    }
}
