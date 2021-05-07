using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAnswerKey : MonoBehaviour
{
    Collider2D HitCollsion;
    AudioSource MyAudio;

    private void Start()
    {
        MyAudio = this.GetComponent<AudioSource>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        HitCollsion = collision;
    }

    private void OnMouseUpAsButton()
    {
        Debug.Log(HitCollsion?.gameObject.name);
        if (HitCollsion?.gameObject.name == "RockFile")
        {
            if (MyAudio.clip.name == GetAnswerSEName())
            {
                Debug.Log("ファイルが開いたよ");
            }
        }
    }

    private string GetAnswerSEName()
    {
        MycomSETable SEList = Resources.Load<MycomSETable>("Scriotable/MycomSETable");
        return SEList.GetSEDatas().Find(data => data.GetSEName() == "CD").SESource.name;
    }
}
