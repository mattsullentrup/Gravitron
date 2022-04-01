using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance { get; private set; }
    [SerializeField] private float spawnRangeX = 8;
    [SerializeField] private float spawnPosZ = 8;
    [SerializeField] private float spawnPosY = 1.5f;
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
        while (PauseManager.paused != true && GameManager.Manager.gameOver != true)
        {
            yield return new WaitForSeconds(enemyOneSpawnInterval);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, spawnPosZ);
            GameObject newEnemyOne = Instantiate(enemyOnePrefab, spawnPos, Quaternion.identity);
            newEnemyOne.GetComponent<EnemyOne>().enemyHealth = 1;
            //yield return new WaitForSecondsRealtime(enemyOneSpawnInterval);
        }
    }

    public IEnumerator SpawnEnemyTwo()
    {
        while (PauseManager.paused != true && GameManager.Manager.gameOver != true)
        {
            yield return new WaitForSeconds(enemyTwoSpawnInterval);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, spawnPosZ);
            GameObject newEnemyTwo = Instantiate(enemyTwoPrefab, spawnPos, Quaternion.identity);
            newEnemyTwo.GetComponent<EnemyTwo>().enemyHealth = 2;
        }
    }

    public IEnumerator SpawnAsteroid()
    {
        while (PauseManager.paused != true && GameManager.Manager.gameOver != true)
        {
            yield return new WaitForSeconds(asteroidSpawnInterval);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, spawnPosZ);
            GameObject newAsteroid = Instantiate(asteroidPrefab, spawnPos, Quaternion.identity);
            newAsteroid.GetComponent<Asteroid>().asteroidHealth = 3;
            //yield return new WaitForSecondsRealtime(asteroidSpawnInterval);
        }
    }

    public IEnumerator SpawnPowerup()
    {
        while (PauseManager.paused != true && GameManager.Manager.gameOver != true)
        {
            yield return new WaitForSeconds(powerupSpawnInterval);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, spawnPosZ);
            GameObject newPowerup = Instantiate(powerupPrefab, spawnPos, Quaternion.identity);
            //yield return new WaitForSecondsRealtime(powerupSpawnInterval);
        }
    }
}
