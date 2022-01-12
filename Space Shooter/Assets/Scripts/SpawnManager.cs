using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemyTwo;
    public GameObject powerup;
    public GameObject asteroid;

    private float spawnRangeX = 10;
    private float spawnPosZ = 10;
    private float spawnPosY = 1.5f;
    private float startDelay = 0.1f;
    private float enemySpawnInterval = 2f;
    private float powerupSpawnInterval = 20f;
    private float asteroidSpawnInterval = 7f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, enemySpawnInterval);
        InvokeRepeating("SpawnEnemyTwo", startDelay, enemySpawnInterval);
        InvokeRepeating("SpawnPowerup", 10f, powerupSpawnInterval);
        InvokeRepeating("SpawnAsteroid", startDelay, asteroidSpawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemy()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, spawnPosZ);
        Instantiate(enemy, spawnPos, enemy.transform.rotation);
    }

    void SpawnEnemyTwo()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, spawnPosZ);
        Instantiate(enemyTwo, spawnPos, enemy.transform.rotation);
    }

    void SpawnPowerup()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, spawnPosZ);
        Instantiate(powerup, spawnPos, enemy.transform.rotation);
    }

    void SpawnAsteroid()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, spawnPosZ);
        Instantiate(asteroid, spawnPos, enemy.transform.rotation);
    }
}
