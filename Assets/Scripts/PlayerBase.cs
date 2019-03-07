using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    LifeDisplay lifeDisplay;

    void Start()
    {
        lifeDisplay = FindObjectOfType<LifeDisplay>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        lifeDisplay.ReduceLives(1);
        Destroy(collision.gameObject, 1f);
    }
}
