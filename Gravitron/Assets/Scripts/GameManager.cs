using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
[System.Serializable]

public class GameManager : MonoBehaviour
{
    public static GameManager Manager { get; set; } //Encapsulation
    public TMP_Text scoreText;
    private int score;
    public bool gameOver;
    public GameObject canvas;
    public GameObject playerHealthThree;
    public GameObject playerHealthTwo;
    public GameObject playerHealthOne;
    public GameObject healthUI;
    private GameObject player;
    public GameObject gameOverFirstButton;
    public GameObject gameOverScreen;

    private void Awake()
    {
        
        if (Manager != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Manager = this;
        }

        //DontDestroyOnLoad(Manager);

    }

    private void Start()
    {
        scoreText = GameObject.Find("Score Text").GetComponent<TextMeshPro>();
        healthUI = GameObject.Find("HealthUI");
        playerHealthThree = GameObject.Find("Player Health Three");
        playerHealthTwo = GameObject.Find("Player Health Two");
        playerHealthOne = GameObject.Find("Player Health One");
        player = GameObject.Find("Player");
        gameOverFirstButton = GameObject.Find("Restart Button");
        gameOverScreen = GameObject.Find("Game Over Screen");
        player.SetActive(true);
        StartGame();
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

    public void GameOver()
    {
        if (player.GetComponent<PlayerHealth>().currentPlayerHealth <= 0)
        {
            gameOver = true;
            gameOverScreen.SetActive(true);
            player.SetActive(false);
            StopAllCoroutines();
            //clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            //set a new selected object
            EventSystem.current.SetSelectedGameObject(gameOverFirstButton);
        }
    }

    public void StartGame()
    {
        player.SetActive(true);
        gameOver = false;
        score = 0;
        UpdateScore(0);
        playerHealthThree.SetActive(true);
        playerHealthTwo.SetActive(true);
        playerHealthOne.SetActive(true);
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
