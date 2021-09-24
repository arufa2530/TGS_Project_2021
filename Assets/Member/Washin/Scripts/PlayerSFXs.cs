using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerSounds
{
    currentSound,
    walk,
    jump,
    fire

}
public class PlayerSFXs : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip walk;
    [SerializeField] AudioClip jump;
    [SerializeField] AudioClip fire;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PickSoundToPlay(PlayerSounds soundToPlay)
    {
        if (soundToPlay == PlayerSounds.walk) PlaySound(walk);
        if(soundToPlay == PlayerSounds.jump) PlaySound(jump);
        if(soundToPlay == PlayerSounds.fire) PlaySound(fire);
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
