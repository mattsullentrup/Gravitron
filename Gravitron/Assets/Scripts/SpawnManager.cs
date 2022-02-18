using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance { get; private set; }
    private float spawnRangeX = 10;
    private float spawnPosZ = 8;
    private float spawnPosY = 1.5f;
    [SerializeField] private float enemyOneSpawnInterval = 4f;
    [SerializeField] private float enemyTwoSpawnInterval = 7f;
    [SerializeField] private float powerupSpawnInterval = 20f;
    [SerializeField] private float asteroidSpawnInterval = 9f;
    [SerializeField] private GameObject enemyOnePrefab;
    [SerializeField] private GameObject enemyTwoPrefab;
    [SerializeField] private GameObject asteroidPrefab;
    [SerializeField] private GameObject powerupPrefab;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
        }
    }

    public IEnumerator SpawnEnemyOne()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(enemyOneSpawnInterval);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, spawnPosZ);
            GameObject newEnemyOne = Instantiate(enemyOnePrefab, spawnPos, Quaternion.identity);
            newEnemyOne.GetComponent<EnemyOne>().enemyHealth = 1;
        }
    }

    public IEnumerator SpawnEnemyTwo()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(enemyTwoSpawnInterval);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, spawnPosZ);
            GameObject newEnemyTwo = Instantiate(enemyTwoPrefab, spawnPos, Quaternion.identity);
            newEnemyTwo.GetComponent<EnemyTwo>().enemyHealth = 2;
        }
    }

    public IEnumerator SpawnAsteroid()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(asteroidSpawnInterval);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, spawnPosZ);
            GameObject newAsteroid = Instantiate(asteroidPrefab, spawnPos, Quaternion.identity);
            newAsteroid.GetComponent<Asteroid>().asteroidHealth = 3;
        }
    }

    public IEnumerator SpawnPowerup()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(powerupSpawnInterval);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, spawnPosZ);
            GameObject newPowerup = Instantiate(powerupPrefab, spawnPos, Quaternion.identity);
        }
    }
}
