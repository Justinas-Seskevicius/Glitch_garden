using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 100;
    [SerializeField] GameObject starPrefab;

    public void AddStars(int amount)
    {
        FindObjectOfType<StarDisplay>().AddStars(amount);
        Instantiate(starPrefab, transform.position + new Vector3(0f, 0.3f), Quaternion.identity);
    }

    public int GetStarCost()
    {
        return starCost;
    }
}
