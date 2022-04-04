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
    public TextMeshProUGUI scoreText;
    private int score;
    public bool gameOver;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject playerHealthThree;
    [SerializeField] private GameObject playerHealthTwo;
    [SerializeField] private GameObject playerHealthOne;
    [SerializeField] private GameObject healthUI;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject gameOverFirstButton;
    public GameObject gameOverScreen;

    //public int currentPlayerHealth;
    //[SerializeField] private PlayerHealth playerHealth;

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

        gameOver = false;

        //DontDestroyOnLoad(Manager);

        player = GameObject.Find("Player");

    }

    private void Start()
    {
        //if (player != null)
        //{
            //player = GameObject.Find("Player");
            //playerHealth = player.GetComponent<PlayerHealth>();
            //currentPlayerHealth = playerHealth.currentPlayerHealth;
        //}

        
        canvas = GameObject.Find("Canvas");
        scoreText = canvas.transform.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>();
        healthUI = GameObject.Find("HealthUI");
        playerHealthThree = healthUI.transform.GetChild(0).gameObject;
        playerHealthTwo = healthUI.transform.GetChild(1).gameObject;
        playerHealthOne = healthUI.transform.GetChild(2).gameObject;

        gameOverFirstButton = canvas.transform.GetChild(3).GetChild(1).gameObject;
        gameOverScreen = canvas.transform.GetChild(3).gameObject;
        //player.SetActive(true);
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
        if (PlayerHealth.currentPlayerHealth <= 0)
        {
            gameOver = true;
            gameOverScreen.SetActive(true);
            //player.SetActive(false);
            StopAllCoroutines();

            //clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            //set a new selected object
            EventSystem.current.SetSelectedGameObject(gameOverFirstButton);
        }
    }

    public void StartGame()
    {
        //player.SetActive(true);
        gameOver = false;
        score = 0;
        UpdateScore(0);
        gameOverScreen.SetActive(false);
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
        if (PlayerHealth.currentPlayerHealth == 2)
        {
            playerHealthThree.SetActive(false);
        }

        if (PlayerHealth.currentPlayerHealth == 1)
        {
            playerHealthTwo.SetActive(false);
        }

        if (PlayerHealth.currentPlayerHealth == 0)
        {
            playerHealthOne.SetActive(false);
        }
    }
}
