using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public static SoundManager instance;
    
    public AudioSource Effects;

    public AudioClip FxCut, FxDeath, FxButtonPlay;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void PlayFX(AudioClip audio)
    {
        Effects.clip = audio;
        Effects.Play();
    }
}
