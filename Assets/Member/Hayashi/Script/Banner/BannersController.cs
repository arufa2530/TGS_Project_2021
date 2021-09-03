using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannersController : MonoBehaviour
{
    [SerializeField] GameObject BannerPrefab;
    GameObject Previousobj = null;
    Vector3 objVec = new Vector3(0f, 0f, 0f);
    int bannerCount = 0;

    public void CreateBanner()
    {
        if (bannerCount < 10)
        {
            GameObject Createobj;
            if (Previousobj == null)
            {
                Createobj = Instantiate(BannerPrefab, objVec, Quaternion.identity);
                Previousobj = Createobj;
            }
            else
            {
                Createobj = Instantiate(BannerPrefab, objVec, Quaternion.identity);
            }
            Createobj.transform.parent = this.transform;
            Createobj.transform.localScale = new Vector3(1f, 1f, 1f);
            objVec += new Vector3(0.1f, -0.1f, 0f);
            bannerCount++;
        }
        else if(bannerCount >= 10)
        {
            GameObject.Find("SoundManager").GetComponent<SoundManagerSc>().PlaySeByName("Error_01");
        }
    }

    public void DestroyBanner()
    {
        bannerCount--;
    }
}
