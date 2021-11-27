using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EndVideo : MonoBehaviour
{ 
    //[SerializeField] ChangeScene changeTemp;
    [SerializeField] NewChangeScreenScript changeTemp;
    [SerializeField] VideoPlayer vPlay;
    [SerializeField] GameObject life;
    // Start is called before the first frame update
    void Start()
    {
        vPlay.loopPointReached += LastPlay;
    }
    public void LastPlay(VideoPlayer vp)
    {
        vPlay.Stop();
        Debug.Log("ha");
        changeTemp.LoadNextScene(0);
    }
    // Update is called once per frame
    void Update()
    {
        life = GameObject.Find("PlayerHolderNew");
        if(life != null)
        {
            //life.gameObject.SetActive(false);
            Destroy(PlayerReferences.theHealthUI.transform.parent.gameObject);
            Destroy(PlayerReferences.thePlayer.gameObject);
        }
    }
}
