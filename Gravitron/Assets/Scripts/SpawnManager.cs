using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float spawnRangeX = 10;
    private float spawnPosZ = 8;
    private float spawnPosY = 1.5f;
    //private float startDelay = 0.1f;
    private float enemyOneSpawnInterval = 4f;
    private float enemyTwoSpawnInterval = 5f;
    private float powerupSpawnInterval = 20f;
    private float asteroidSpawnInterval = 7f;
    private GameManager gameManager;
    public Vector3 enemyOneSpawnPos;
    public static SpawnManager Instance;

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
            //DontDestroyOnLoad(gameObject);

        }
    }

    //private void OnEnable()
    //{
    //    StartCoroutine(SpawnEnemyOne());
    //}

    // Start is called before the first frame update
    void Start()
    {
        enemyOneSpawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, spawnPosZ);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        //StartCoroutine(SpawnEnemyOne());
        //StartCoroutine(SpawnEnemyTwo());
        //StartCoroutine(SpawnPowerup());
        //StartCoroutine(SpawnAsteroid());


        //InvokeRepeating(nameof(SpawnEnemyOne), startDelay, enemyOneSpawnInterval);
        //InvokeRepeating(nameof(SpawnEnemyTwo), startDelay, enemyTwoSpawnInterval);
        //InvokeRepeating(nameof(SpawnPowerup), 10f, powerupSpawnInterval);
        //InvokeRepeating(nameof(SpawnAsteroid), startDelay, asteroidSpawnInterval);
    }

    private void Update()
    {
        //if (gameManager.gameOver == true)
        //{
        //    StopAllCoroutines();
        //}
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
