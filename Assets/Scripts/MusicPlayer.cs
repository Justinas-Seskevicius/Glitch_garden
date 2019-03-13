using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] float defaultVolume = 0.1f;
    AudioSource audioSource;

    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        if (FindObjectsOfType<MusicPlayer>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
            audioSource.volume = PlayerPrefsController.GetMasterVolume(defaultVolume);
        }
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

}
