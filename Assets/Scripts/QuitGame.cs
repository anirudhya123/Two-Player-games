using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{

    AudioManager audioManager;
    public AudioClip clip;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void PlaySound(AudioClip clip)
    {
        audioManager.PlayParticular(clip);
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Escape)){
            Application.Quit();
        }
    }
    
}
