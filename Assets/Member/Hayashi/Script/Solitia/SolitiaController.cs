using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolitiaController : MonoBehaviour
{
    [SerializeField] GameObject CardPrefab;
    [SerializeField] GameObject DrawZone;
    [SerializeField] GameObject Solitia;
    CardState cardState;
    GameObject Previousobj = null;
    Vector3 objVec = new Vector3(0f, 0f, 0f);

    public void CreateCard()
    {
        GameObject Createobj;
        if (Previousobj == null)
        {
            Createobj = Instantiate(CardPrefab, objVec, Quaternion.identity);
            Previousobj = Createobj;
        }
        else
        {
            Createobj = Instantiate(CardPrefab, objVec, Quaternion.identity);
        }
        Createobj.transform.parent = DrawZone.transform;
        Createobj.GetComponent<RectTransform>().anchoredPosition = objVec;
        Createobj.transform.localScale = new Vector3(1f, 1f, 1f);
        objVec += new Vector3(1.5f, 0f, 0f);
    }

    public void DestroyWindow()
    {
        Destroy(Solitia.gameObject);
    }
}
