using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] randomPrefab;

    public bool spawnAtAwake;
    private GameObject pickupPrefab;
    public float spawnDelay;
    private float nextSpawnTime;
    private Transform tf;

    private GameObject spawnedPickup;

    // Start is called before the first frame update

    public void Awake()
    {
        if (spawnAtAwake == true)
        {
            pickupPrefab = randomPrefab[Random.Range(0, randomPrefab.Length)];
            spawnedPickup = Instantiate(pickupPrefab, transform.position, Quaternion.identity) as GameObject;
         
        }
    }
    void Start()
    {
        nextSpawnTime = Time.time + spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        // If it is there is nothing spawns
        if (spawnedPickup == null)
        {
            // And it is time to spawn
            if (Time.time > nextSpawnTime)
            {
              pickupPrefab = randomPrefab[Random.Range(0, randomPrefab.Length)];
                // Spawn it and set the next time
                spawnedPickup = Instantiate(pickupPrefab, transform.position, Quaternion.identity) as GameObject;
                nextSpawnTime = Time.time + spawnDelay;
            }
        }
        else
        {
            // Otherwise, the object still exists, so postpone the spawn
            nextSpawnTime = Time.time + spawnDelay;
        }
    }
}
