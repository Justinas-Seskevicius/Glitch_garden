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
        if (lives >= amount)
        {
            lives -= amount;
            UpdateDisplay();
        }
        else
        {
            lives = 0;
            UpdateDisplay();
            levelLoader.LoadStartScene(loadDelay);
        }
    }
}
