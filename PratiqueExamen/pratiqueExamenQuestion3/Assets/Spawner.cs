using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnRate = 2;
    private float timeLeftBeforeSpawn = 0;
    private SpawnPoint[] spawnPoints;
    public GameObject enemyPrefrab;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = FindObjectsOfType<SpawnPoint>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSpawn();
    }

    private void UpdateSpawn()
    {
        timeLeftBeforeSpawn -= Time.deltaTime;
        if (timeLeftBeforeSpawn <= 0)
        {
            SpawnEnnemy();
            timeLeftBeforeSpawn = spawnRate;
        }
    }

    private void SpawnEnnemy()
    {
        int countSpawnPoints = spawnPoints.Length;
        int randomSpawnPointIndex = Random.Range(0, countSpawnPoints - 1);
        SpawnPoint currentSpawnPoint = spawnPoints[randomSpawnPointIndex];
        GameObject enemy = Instantiate(enemyPrefrab, currentSpawnPoint.transform.position, Quaternion.identity);
        enemy.transform.Rotate(new Vector3(0, 0, 90));
    }
}
