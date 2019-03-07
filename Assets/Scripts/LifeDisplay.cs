using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeDisplay : MonoBehaviour
{
    [SerializeField] int lives = 20;
    [SerializeField] float loadDelay = 2f;
    TextMeshProUGUI lifeText;
    LevelLoader levelLoader;

    void Start()
    {
        lifeText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
        levelLoader = FindObjectOfType<LevelLoader>();
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
            levelLoader.LoadLoseScreen(loadDelay);
        }
    }
}
