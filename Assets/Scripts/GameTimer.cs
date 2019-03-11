using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level timer in SECONDS")]
    [SerializeField] float levelTime = 10f;

    bool triggeredLevelEnd = false;

    void Update()
    {
        if(triggeredLevelEnd) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        bool timerFinished = Time.timeSinceLevelLoad >= levelTime;
        if (timerFinished)
        {
            triggeredLevelEnd = true;
            FindObjectOfType<LevelController>().LevelTimerFinished();
        }
    }
}
