﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravestone : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D otherCollider)
    {
        Attacker attacker = otherCollider.gameObject.GetComponent<Attacker>();

        if(attacker)
        {
            // TODO add some kind of animation event
        }
    }
}
