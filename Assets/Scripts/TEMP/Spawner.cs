using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemiesPrefabs;
    [SerializeField] private float minSecsToSpawn = 1, maxSecsToSpawn = 3;
    private float secsToSpawn;
    private float elapsed = 0;

    private void Awake()
    {
        secsToSpawn = Random.Range(minSecsToSpawn, maxSecsToSpawn);
    }

    private void FixedUpdate()
    {
        elapsed+=Time.deltaTime;
        if (elapsed > secsToSpawn)
        {
            elapsed = 0;
            Spawn();
        }
    }

    private void Spawn()
    {
        Instantiate(enemiesPrefabs[0], transform);
        secsToSpawn = Random.Range(minSecsToSpawn, maxSecsToSpawn);
    }
}
