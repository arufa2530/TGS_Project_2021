using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    MycomSETable SEList;

    public void SetSESource()
    {
        SEList = Resources.Load<MycomSETable>("Scriotable/MycomSETable");
        for (int i = 0; i < SEList.SEDataList.Count; i++)
        {
            SEData SEData = SEList.SEDataList[i];
            if (SEData.Name == this.name)
            {
                GameObject.Find("SoundManager").GetComponent<SoundManagerSc>().PlaySeByName(SEData.SESource.name);
            }
        }
    }
}
