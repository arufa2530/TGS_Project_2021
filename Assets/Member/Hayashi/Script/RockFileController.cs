using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFileController : MonoBehaviour
{
    AudioSource MyAudio;

    [SerializeField] AudioClip[] Clips = new AudioClip[2];

    private void Start()
    {
        MyAudio = this.GetComponent<AudioSource>();
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
