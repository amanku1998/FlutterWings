using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    [SerializeField] private float minSpawnRate = 0.5f; // Minimum time between spawns
    [SerializeField] private float maxSpawnRate = 2f;   // Maximum time between spawns
    [SerializeField] private float minHeight = -1f;
    [SerializeField] private float maxHeight = 1f;

    private Coroutine spawnCoroutine;

    private void OnEnable()
    {
        spawnCoroutine = StartCoroutine(SpawnRandomly());
    }
    
    private void OnDisable()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
        }
    }

    private IEnumerator SpawnRandomly()
    {
        while (true)
        {
            Spawn();
            float randomDelay = Random.Range(minSpawnRate, maxSpawnRate);
            yield return new WaitForSeconds(randomDelay);
        }
    }

    //
    private void Spawn()
    {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
