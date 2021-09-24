using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingSE : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    public void PlayPlayerShootingSE()
    {
        audioSource.Play();
    }
    public void StopShootingSE()
    {
        audioSource.Stop();
    }

}
