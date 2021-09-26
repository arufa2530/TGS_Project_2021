using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAnswerKey : MonoBehaviour
{
    DriveController DCon;

    Collider2D HitCollsion;
    AudioSource MyAudio;
    [SerializeField] GameObject talk;
    Conversatio_UI Conversatio;

    private void Start()
    {
        DCon = GameObject.Find("D:").GetComponent<DriveController>();
        MyAudio = this.GetComponent<AudioSource>();
        if(talk != null)Conversatio = talk.GetComponent<Conversatio_UI>();
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
            MycomSETable SEList;
            SEList = Resources.Load<MycomSETable>("Scriotable/MycomSETable");
            string sename = "";
            for (int i = 0; i < SEList.SEDataList.Count; i++)
            {
                SEData SEData = SEList.SEDataList[i];
                if (SEData.Name == this.name)
                {
                    sename = SEData.SESource.name;
                }
            }
            if (sename == GetAnswerSEName() && DCon.IsLoadCD)
            {
                GameObject.Find("RockFile").GetComponent<RockFileController>().PlaySound1();
                if (talk != null) Conversatio.TalkVo(10);
                Debug.Log("ファイルが開いたよ");
            }
            else
                GameObject.Find("RockFile").GetComponent<RockFileController>().PlaySound2();
        }
    }

    private string GetAnswerSEName()
    {
        MycomSETable SEList = Resources.Load<MycomSETable>("Scriotable/MycomSETable");
        return SEList.GetSEDatas().Find(data => data.GetSEName() == "D:").SESource.name;
    }
}
