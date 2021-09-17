using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemTable : ScriptableObject
{
    public List<ItemData> ItemDataList = new List<ItemData>();

    public List<ItemData> GetItemDatas()
    {
        return ItemDataList;
    }
}

[System.Serializable]
public class ItemData
{
    public string Name;
    public Sprite Image;
    public string explanation;
}
