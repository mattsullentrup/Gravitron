using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[System.Serializable]

public class GameManager : MonoBehaviour
{
    public static GameManager Manager { get; private set; } //Encapsulation
    public GameObject titleScreen;
    public Text scoreText;
    public Text gameOverText;
    public Button restartButton;
    public bool gameOver;
    public GameObject playerHealthThree;
    public GameObject playerHealthTwo;
    public GameObject playerHealthOne;
    public GameObject healthUI;
    private int score;
    private GameObject player;

    private void Awake()
    {
        gameOver = true;

        if (Manager != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Manager = this;
        }
    }

    private void Start()
    {
        player = GameObject.Find("Player");
        
        UpdateScore(0);
    }

    private void Update()
    {
        //Abstraction
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
        StartCoroutine(SpawnManager.Instance.SpawnEnemyOne());
        StartCoroutine(SpawnManager.Instance.SpawnEnemyTwo());
        StartCoroutine(SpawnManager.Instance.SpawnPowerup());
        StartCoroutine(SpawnManager.Instance.SpawnAsteroid());
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
