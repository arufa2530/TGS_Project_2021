using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerSounds
{
    currentSound,
    walk,
    jump
}
public class PlayerSFXs : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip walk;
    [SerializeField] AudioClip jump;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PickSoundToPlay(PlayerSounds soundToPlay)
    {
        if (soundToPlay == PlayerSounds.walk) PlaySound(walk);
        if(soundToPlay == PlayerSounds.jump) PlaySound(jump);
    }

    void PlaySound(AudioClip pickedSound)
    {
        audioSource.clip = pickedSound;
        audioSource.Play();
    }

    public void StopPlayingSound()
    {
        audioSource.Stop();
    }

    public bool IsPlayingSound()
    {
        return audioSource.isPlaying;
    }
}
