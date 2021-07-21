using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannersController : MonoBehaviour
{
    [SerializeField] GameObject BannerPrefab;
    public void CreateBanner()
    {
        GameObject Createobj = Instantiate(BannerPrefab, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);

        Createobj.transform.parent = this.transform;
        Createobj.transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
