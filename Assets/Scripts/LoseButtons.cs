using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseButtons : MonoBehaviour
{
    public void ResetCurrentLevel()
    {
        FindObjectOfType<LevelLoader>().ReloadCurrentScene();
    }

    public void ReturnToMainMenu()
    {
        FindObjectOfType<LevelLoader>().LoadStartScreen();
    }
}
