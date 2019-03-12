using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float loadingTime = 3f;
    int currentSceneIndex;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            LoadNextScene();
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScreen()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }

    public void ReloadCurrentScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadOptionsScreen()
    {
        SceneManager.LoadScene("Options Screen");
    }

    public void LoadLoseScreen()
    {
        StartCoroutine(LoseScreenCoroutine(loadingTime));
    }

    IEnumerator LoseScreenCoroutine(float loadDelay)
    {
        yield return new WaitForSeconds(loadDelay);
        SceneManager.LoadScene("Lose Screen");
    }
}
