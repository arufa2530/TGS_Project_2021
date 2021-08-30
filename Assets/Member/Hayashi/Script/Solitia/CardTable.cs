using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CardTable : ScriptableObject
{
    public List<CardKinds> CardKindsList = new List<CardKinds>();

    public List<CardKinds> GetCardKindsDatas() { return CardKindsList; }
}

[System.Serializable]
public class CardKinds
{
    public string name;
    public int kindsnumber;

    public List<CardData> CardDataList = new List<CardData>();

    public List<CardData> GetCardDatas() { return CardDataList; }
}

[System.Serializable]
public class CardData
{
    public int number;
    public Sprite Image;

    public Sprite GetImage() { return Image; }
}
