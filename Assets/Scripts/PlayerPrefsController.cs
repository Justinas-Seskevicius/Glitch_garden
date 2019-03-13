using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string VOLUME_KEY = "volume";
    const string DIFFICULTY_KEY = "difficulty";

    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;

    const int MIN_DIFFICULTY = 0;
    const int MAX_DIFFICULTY = 2;

    public static void SetMasterVolume(float volume)
    {
        if(volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            PlayerPrefs.SetFloat(VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Master volume is out of bounds -> " + volume);
        }
    }

    public static void SetDifficulty(int difficulty)
    {
        if (difficulty >= MIN_DIFFICULTY && difficulty <= MAX_VOLUME)
        {
            PlayerPrefs.SetInt(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("Difficulty is out of bounds -> " + difficulty);
        }
    }

    public static float GetMasterVolume(float defaultVolume)
    {
        return PlayerPrefs.GetFloat(VOLUME_KEY, defaultVolume);
    }

    public static int GetDifficulty(int defaultDifficulty)
    {
        return PlayerPrefs.GetInt(DIFFICULTY_KEY, defaultDifficulty);
    }
}
