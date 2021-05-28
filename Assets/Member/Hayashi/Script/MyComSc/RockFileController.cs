using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFileController : MonoBehaviour
{
    AudioSource MyAudio;

    [SerializeField] AudioClip[] Clips = new AudioClip[3];

    private void Start()
    {
        MyAudio = this.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!MyAudio.clip == Clips[2])
        {
            MyAudio.clip = Clips[2];
        }
    }

    public void PlaySound1()
    {
        MyAudio.PlayOneShot(Clips[0]);
    }

    public void PlaySound2()
    {
        MyAudio.PlayOneShot(Clips[1]);
    }
}
