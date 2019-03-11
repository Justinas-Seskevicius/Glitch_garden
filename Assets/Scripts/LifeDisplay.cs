using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeDisplay : MonoBehaviour
{
    [SerializeField] int lives = 20;
    TextMeshProUGUI lifeText;

    void Start()
    {
        lifeText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
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
