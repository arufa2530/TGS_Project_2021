using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] AudioSource audioSource;
    [SerializeField] float maxVolume;
    [SerializeField] float fadeInTime;
    [SerializeField] float fadeOutTime;
    private void Start()
    {
        AudioManager.instance = this;
        StartCoroutine(FadeAudioIn());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) StartCoroutine(FadeAudioOut());
    }

    public IEnumerator FadeAudioIn()
    {
        while (audioSource.volume < maxVolume)
        {
            audioSource.volume += Time.deltaTime / fadeInTime;
            //Debug.Log(audioSource.volume);
            yield return null;
        }
        audioSource.volume = maxVolume;
    }

    public IEnumerator FadeAudioOut()
    {
        while (audioSource.volume > 0)
        {
            audioSource.volume -= Time.deltaTime / fadeOutTime;
            //Debug.Log(audioSource.volume);
            yield return null;
        }
        audioSource.volume = 0;
        Debug.Log("Music Stopped");
        audioSource.Stop();
    }

    public void StartFadeOut()
    {
        StartCoroutine(FadeAudioOut());
    }
}
