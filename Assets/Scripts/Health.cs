using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] GameObject deathVFX;

    public void DealDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX()
    {
        if(!deathVFX) { return; }
        Vector3 adjustedPosition = transform.position - new Vector3(-1.5f, 0f);
        GameObject deathVFXObject = Instantiate(deathVFX, adjustedPosition, transform.rotation);
        Destroy(deathVFXObject, 2f);
    }
}
