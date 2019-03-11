using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] float delayBeforeLoad = 3f;
    int numberOfAttackers = 0;
    bool timerFinished = false;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;

        if (timerFinished && numberOfAttackers == 0)
        {
            StartCoroutine(LevelWinSequence());
        }
    }

    private IEnumerator LevelWinSequence()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(delayBeforeLoad);
        GetComponent<LevelLoader>().LoadNextScene();
    }

    public void LevelTimerFinished()
    {
        timerFinished = true;
        StopSpawners();
    }

    public void LevelLoseSequence()
    {
        Time.timeScale = 0;
        FindObjectOfType<DefenderSpawner>().gameObject.SetActive(false);
        loseLabel.SetActive(true);
    }

    private void StopSpawners()
    {
        var spawners = FindObjectsOfType<EnemySpawner>();
        foreach(EnemySpawner spawner in spawners)
        {
            spawner.StopSpawning();
        }
    }
}
