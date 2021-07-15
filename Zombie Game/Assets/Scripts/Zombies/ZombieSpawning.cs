using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawning : MonoBehaviour
{
    [SerializeField] GameObject walkerPrefab;

    float timeToNextSpawn = 0;

    float spawnDelay = 5f;

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        if (timeToNextSpawn < Time.realtimeSinceStartup)
        {
            var zombie = Instantiate(walkerPrefab);
            timeToNextSpawn = Time.realtimeSinceStartup + spawnDelay;
        }
    }
}
