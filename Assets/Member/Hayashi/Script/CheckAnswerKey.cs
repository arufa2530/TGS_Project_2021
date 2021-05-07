using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAnswerKey : MonoBehaviour
{
    DriveController DCon;

    Collider2D HitCollsion;
    AudioSource MyAudio;

    private void Start()
    {
        DCon = GameObject.Find("D:").GetComponent<DriveController>();
        MyAudio = this.GetComponent<AudioSource>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        HitCollsion = collision;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        HitCollsion = null;
    }

    private void OnMouseUpAsButton()
    {
        Debug.Log(HitCollsion?.gameObject.name);
        if (HitCollsion?.gameObject.name == "RockFile")
        {
            if (MyAudio.clip.name == GetAnswerSEName() && DCon.IsLoadCD)
            {
                GameObject.Find("RockFile").GetComponent<RockFileController>().PlaySound1();
                Debug.Log("ファイルが開いたよ");
            }
            else
                GameObject.Find("RockFile").GetComponent<RockFileController>().PlaySound2();
        }
    }

    private string GetAnswerSEName()
    {
        MycomSETable SEList = Resources.Load<MycomSETable>("Scriotable/MycomSETable");
        return SEList.GetSEDatas().Find(data => data.GetSEName() == "CD").SESource.name;
    }
}
