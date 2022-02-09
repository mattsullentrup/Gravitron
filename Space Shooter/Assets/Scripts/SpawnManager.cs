using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float spawnRangeX = 10;
    private float spawnPosZ = 8;
    private float spawnPosY = 1.5f;
    private float startDelay = 0.1f;
    private float enemyOneSpawnInterval = 4f;
    private float enemyTwoSpawnInterval = 3f;
    private float powerupSpawnInterval = 20f;
    private float asteroidSpawnInterval = 7f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, enemyOneSpawnInterval);
        InvokeRepeating("SpawnEnemyTwo", startDelay, enemyTwoSpawnInterval);
        InvokeRepeating("SpawnPowerup", 10f, powerupSpawnInterval);
        InvokeRepeating("SpawnAsteroid", startDelay, asteroidSpawnInterval);
    }

    void SpawnEnemy()
    {
        GameObject enemyOne = ObjectPooler.Instance.GetPooledObject("Enemy");
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, spawnPosZ);

        if (enemyOne != null)
        {
            enemyOne.transform.position = spawnPos;
            enemyOne.transform.rotation = enemyOne.transform.rotation;
            enemyOne.GetComponent<EnemyOne>().enemyHealth = 1;
            enemyOne.SetActive(true);
        }
    }

    void SpawnEnemyTwo()
    {
        GameObject enemyTwo = ObjectPooler.Instance.GetPooledObject("Enemy Two");
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, spawnPosZ);

        if (enemyTwo != null)
        {
            enemyTwo.transform.position = spawnPos;
            enemyTwo.transform.rotation = enemyTwo.transform.rotation;
            enemyTwo.GetComponent<EnemyTwo>().enemyHealth = 2;
            enemyTwo.SetActive(true);
        }
    }

    void SpawnPowerup()
    {
        GameObject powerup = ObjectPooler.Instance.GetPooledObject("Powerup");
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, spawnPosZ);

        if (powerup != null)
        {
            powerup.transform.position = spawnPos;
            powerup.transform.rotation = powerup.transform.rotation;
            powerup.SetActive(true);
        }
    }

    void SpawnAsteroid()
    {
        GameObject asteroid = ObjectPooler.Instance.GetPooledObject("Asteroid");
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, spawnPosZ);

        if (asteroid != null)
        {
            asteroid.transform.position = spawnPos;
            asteroid.transform.rotation = asteroid.transform.rotation;
            asteroid.GetComponent<Asteroid>().asteroidHealth = 3;
            asteroid.SetActive(true);
        }

        //Instantiate(asteroid, spawnPos, enemy.transform.rotation);
    }
}
