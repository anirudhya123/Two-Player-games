using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayRandom(AudioClip[] sounds)
    {
        AudioClip clip = sounds[Random.Range(0,sounds.Length)];
        audioSource.PlayOneShot(clip);
    }

    public void PlayParticular(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
