using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SoundManagerSc : SingletonMonoBehaviour<SoundManagerSc>
{
    float bgmVolume = 1;
    float seVolume = 1;

    AudioClip[] bgm;
    AudioClip[] se;

    Dictionary<string, int> bgmIndex = new Dictionary<string, int>();
    Dictionary<string, int> seIndex = new Dictionary<string, int>();

    AudioSource bgmAudioSource;
    AudioSource seAudioSource;

    public float BgmVolume
    {
        set
        {
            bgmVolume = Mathf.Clamp01(value);
            bgmAudioSource.volume = bgmVolume;
        }
        get
        {
            return bgmVolume;
        }
    }

    public float SeVolume
    {
        set
        {
            seVolume = Mathf.Clamp01(value);
            seAudioSource.volume = seVolume;
        }
        get
        {
            return seVolume;
        }
    }


    public void Awake()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        bgmAudioSource = gameObject.AddComponent<AudioSource>();
        seAudioSource = gameObject.AddComponent<AudioSource>();

        bgm = Resources.LoadAll<AudioClip>("Sound/BGM");
        se = Resources.LoadAll<AudioClip>("Sound/SE");

        for (int i = 0; i < bgm.Length; i++)
        {
            bgmIndex.Add(bgm[i].name, i);
        }

        for (int i = 0; i < se.Length; i++)
        {
            seIndex.Add(se[i].name, i);
        }
    }

    // 番号取得
    public int GetBgmIndex(string name)
    {
        if (bgmIndex.ContainsKey(name))
        {
            return bgmIndex[name];
        }
        else
        {
            Debug.LogError("指定された名前のBGMファイルが存在しません。");
            return 0;
        }
    }

    public int GetSeIndex(string name)
    {
        if (seIndex.ContainsKey(name))
        {
            return seIndex[name];
        }
        else
        {
            Debug.LogError("指定された名前のSEファイルが存在しません。");
            return 0;
        }
    }

    //BGM再生
    public void PlayBgm(int index)
    {
        index = Mathf.Clamp(index, 0, bgm.Length);

        bgmAudioSource.clip = bgm[index];
        bgmAudioSource.loop = true;
        bgmAudioSource.volume = BgmVolume;
        bgmAudioSource.Play();
    }

    public void PlayBgmByName(string name)
    {
        PlayBgm(GetBgmIndex(name));
    }

    public void StopBgm()
    {
        bgmAudioSource.Stop();
        bgmAudioSource.clip = null;
    }

    //SE再生
    public void PlaySe(int index)
    {
        index = Mathf.Clamp(index, 0, se.Length);

        seAudioSource.PlayOneShot(se[index], SeVolume);
    }

    public void PlaySeByName(string name)
    {
        PlaySe(GetSeIndex(name));
    }

    public void StopSe()
    {
        seAudioSource.Stop();
        seAudioSource.clip = null;
    }

    //　固有Volume
    public void UniquePlayBgm(int index, int volume)
    {
        index = Mathf.Clamp(index, 0, bgm.Length);

        bgmAudioSource.clip = bgm[index];
        bgmAudioSource.loop = true;
        bgmAudioSource.volume = volume;
        bgmAudioSource.Play();
    }

    public void UniquePlaySe(int index, int volume)
    {
        index = Mathf.Clamp(index, 0, se.Length);

        seAudioSource.PlayOneShot(se[index], volume);
    }
}
