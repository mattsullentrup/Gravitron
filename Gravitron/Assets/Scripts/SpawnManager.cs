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
    private GameManager gameManager;
    public Vector3 enemyOneSpawnPos;

    // Start is called before the first frame update
    void Start()
    {
        enemyOneSpawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, spawnPosZ);

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        InvokeRepeating(nameof(SpawnEnemy), startDelay, enemyOneSpawnInterval);
        InvokeRepeating(nameof(SpawnEnemyTwo), startDelay, enemyTwoSpawnInterval);
        InvokeRepeating(nameof(SpawnPowerup), 10f, powerupSpawnInterval);
        InvokeRepeating(nameof(SpawnAsteroid), startDelay, asteroidSpawnInterval);

    }

    private void Update()
    {
        if (gameManager.gameOver == true)
        {
            CancelInvoke();
        }
    }

    void SpawnEnemy()
    {
        GameObject enemyOne = ObjectPooler.Instance.GetPooledObject("Enemy");
        Vector3 enemyOneSpawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, spawnPosZ);

        if (enemyOne != null)
        {
            enemyOne.transform.SetPositionAndRotation(enemyOneSpawnPos, enemyOne.transform.rotation);
            enemyOne.GetComponent<EnemyOne>().enemyHealth = 1;
            enemyOne.SetActive(true);
        }
    }

    private void SpawnEnemyTwo()
    {
        GameObject enemyTwo = ObjectPooler.Instance.GetPooledObject("Enemy Two");
        Vector3 enemyTwoSpawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, spawnPosZ);

        if (enemyTwo != null)
        {
            enemyTwo.transform.SetPositionAndRotation(enemyTwoSpawnPos, enemyTwo.transform.rotation);
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
            powerup.transform.SetPositionAndRotation(spawnPos, powerup.transform.rotation);
            powerup.SetActive(true);
        }
    }

    void SpawnAsteroid()
    {
        GameObject asteroid = ObjectPooler.Instance.GetPooledObject("Asteroid");
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, spawnPosZ);

        if (asteroid != null)
        {
            asteroid.transform.SetPositionAndRotation(spawnPos, asteroid.transform.rotation);
            asteroid.GetComponent<Asteroid>().asteroidHealth = 3;
            asteroid.SetActive(true);
        }

        //Instantiate(asteroid, spawnPos, enemy.transform.rotation);
    }
}
