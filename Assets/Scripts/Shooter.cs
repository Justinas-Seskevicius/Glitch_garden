using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] Projectile projectile;
    [SerializeField] GameObject gun;

    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";
    EnemySpawner myLaneSpawner;
    Animator animator;

    private void Start()
    {
        SetProjectileParent();
        SetLaneSpawner();
        animator = GetComponent<Animator>();  
    }

    private void SetProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void Update()
    {
        if(IsAttackerInLane())
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    public void Fire()
    {
        Projectile newProjectile = Instantiate(projectile, gun.transform.position, gun.transform.rotation) as Projectile;
        newProjectile.transform.parent = projectileParent.transform;
    }

    private bool IsAttackerInLane()
    {
        return myLaneSpawner.transform.childCount > 0;
    }

    private void SetLaneSpawner()
    {
        EnemySpawner[] enemySpawners = FindObjectsOfType<EnemySpawner>();

        foreach (EnemySpawner spawner in enemySpawners)
        {
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= 0.2f);
            if(isCloseEnough)
            {
                myLaneSpawner = spawner;
                break;
            }
        }
    }
}
