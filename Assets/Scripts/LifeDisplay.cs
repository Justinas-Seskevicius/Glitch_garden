using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LifeDisplay : MonoBehaviour
{
    int lives;
    TextMeshProUGUI lifeText;
    const int maxLives = 10;
    const int reduceLivesPerDifficulty = 5;
    const int defaultDifficulty = 0;

    void Start()
    {
        lifeText = GetComponent<TextMeshProUGUI>();
        SetUpLives();
        UpdateDisplay();
    }

    private void SetUpLives()
    {
        int difficulty = PlayerPrefsController.GetDifficulty(defaultDifficulty);
        int adjustedLives = maxLives - (reduceLivesPerDifficulty * difficulty);
        if(adjustedLives <= 0)
        {
            lives = 1;
        }
        else
        {
            lives = adjustedLives;
        }
    }

    private void UpdateDisplay()
    {
        lifeText.text = lives.ToString();
    }

    public void ReduceLives(int amount)
    {
        lives -= amount;
        if (lives > 0)
        {
            UpdateDisplay();
        }
        else
        {
            lives = 0;
            UpdateDisplay();
            FindObjectOfType<LevelController>().LevelLoseSequence();
        }
    }
}
