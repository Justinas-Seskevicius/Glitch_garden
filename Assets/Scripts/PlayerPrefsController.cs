using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string VOLUME_KEY = "volume";
    const string DIFFICULTY_KEY = "difficulty";

    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;

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

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(VOLUME_KEY);
    }
}
