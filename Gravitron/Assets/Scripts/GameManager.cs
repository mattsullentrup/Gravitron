using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[System.Serializable]

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject titleScreen;
    public Text scoreText;
    public Text gameOverText;
    public Button restartButton;
    public bool gameOver;
    private int score;
    private GameObject player;
    public SpawnManager spawnManager;
    public GameObject playerHealthThree;
    public GameObject playerHealthTwo;
    public GameObject playerHealthOne;
    public GameObject healthUI;

    private void Awake()
    {
        gameOver = true;

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

    //private void Awake()
    //{
        
    //    //titleScreen.SetActive(false);
    //    //scoreText.gameObject.SetActive(false);
    //    //restartButton.gameObject.SetActive(false);
    //    //gameOverText.gameObject.SetActive(false);
    //}

    private void Start()
    {
        player = GameObject.Find("Player");
        
        UpdateScore(0);
    }

    private void Update()
    {
        GameOver();
        CheckPlayerHealth();
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    private void GameOver()
    {
        if (player.GetComponent<PlayerHealth>().currentPlayerHealth <= 0)
        {
            gameOver = true;
            restartButton.gameObject.SetActive(true);
            gameOverText.gameObject.SetActive(true);
            player.SetActive(false);
            StopAllCoroutines();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        gameOver = false;
        score = 0;
        UpdateScore(0);
        titleScreen.SetActive(false);
        scoreText.gameObject.SetActive(true);
        healthUI.SetActive(true);
        StartCoroutine(spawnManager.SpawnEnemyOne());
        StartCoroutine(spawnManager.SpawnEnemyTwo());
        StartCoroutine(spawnManager.SpawnPowerup());
        StartCoroutine(spawnManager.SpawnAsteroid());
    }

    private void CheckPlayerHealth()
    {
        if (player.GetComponent<PlayerHealth>().currentPlayerHealth == 2)
        {
            playerHealthThree.SetActive(false);
        }

        if (player.GetComponent<PlayerHealth>().currentPlayerHealth == 1)
        {
            playerHealthTwo.SetActive(false);
        }

        if (player.GetComponent<PlayerHealth>().currentPlayerHealth == 0)
        {
            playerHealthOne.SetActive(false);
        }
    }
}
