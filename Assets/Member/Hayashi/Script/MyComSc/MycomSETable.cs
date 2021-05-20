using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MycomSETable : ScriptableObject
{
    public List<SEData> SEDataList = new List<SEData>();

    public List<SEData> GetSEDatas()
    {
        return SEDataList;
    }
}

[System.Serializable]
public class SEData
{
    public string Name;
    public AudioClip SESource;

    public string GetSEName()
    {
        return Name;
    }
}
