using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorWindowPlayRandomSoundScript : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] sound;

    void Start()
    {
        GetRandomSound();
    }

    void GetRandomSound()
    {
        int random = Random.Range(0, 2);
        if (random == 0)
        {
            audioSource.clip = sound[0];
            audioSource.Play();
        }
        else StartCoroutine("LongSound");
    }

    IEnumerator LongSound()
    {
        audioSource.clip = sound[1];
        audioSource.Play();
        yield return new WaitForSeconds(.7f);
        //yield return new WaitWhile(() => audioSource.isPlaying);
        audioSource.clip = sound[2];
        audioSource.Play();
        yield return null;
    }


}
