using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float loadingTime = 3f;
    int currentSceneIndex;

    // Start is called before the first frame update
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
        StartCoroutine(NextSceneLoadCoroutine(loadingTime));
    }

    IEnumerator NextSceneLoadCoroutine(float loadDelay)
    {
        yield return new WaitForSeconds(loadDelay);
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadStartScene(float loadDelay)
    {
        StartCoroutine(StartScreenLoadCoroutine(loadDelay));
    }

    IEnumerator StartScreenLoadCoroutine(float loadDelay)
    {
        yield return new WaitForSeconds(loadDelay);
        SceneManager.LoadScene(0);
    }
}
