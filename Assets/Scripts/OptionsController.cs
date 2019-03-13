using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.1f;
    [SerializeField] Slider difficultySlider;
    [SerializeField] int defaultDifficulty = 0;

    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume(defaultVolume);
        difficultySlider.value = PlayerPrefsController.GetDifficulty(defaultDifficulty);
    }

    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if(musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogError("No music player found!");
        }
    }

    public void SaveOptionsAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        int difficulty = Mathf.RoundToInt(difficultySlider.value);
        PlayerPrefsController.SetDifficulty(difficulty);
        FindObjectOfType<LevelLoader>().LoadStartScreen();
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
}
