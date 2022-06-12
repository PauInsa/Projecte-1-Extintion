using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    public AudioSource audioSource;

    public void PlaySound(AudioClip clip1)
    {
        audioSource.clip = clip1;
        audioSource.loop = false;
        audioSource.Play();
    }
}
