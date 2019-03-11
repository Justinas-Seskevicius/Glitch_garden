using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Attacker[] attackerPrefabs;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;

    bool spawn = true;

    void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    IEnumerator SpawnCoroutine()
    {
        while(spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        int randomIndex = Random.Range(0, attackerPrefabs.Length);
        Spawn(attackerPrefabs[randomIndex]);
    }

    private void Spawn(Attacker attackerPrefab)
    {
        Attacker newAttacker = Instantiate(attackerPrefab, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }
}
