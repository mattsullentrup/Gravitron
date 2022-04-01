using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
[System.Serializable]

public class GameManager : MonoBehaviour
{
    public static GameManager Manager { get; set; } //Encapsulation
    public TMPro.TMP_Text scoreText;
    public bool gameOver;
    public GameObject playerHealthThree;
    public GameObject playerHealthTwo;
    public GameObject playerHealthOne;
    public GameObject healthUI;
    private int score;
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

        DontDestroyOnLoad(Manager);

    }

    private void Start()
    {
        player = GameObject.Find("Player");
        player.SetActive(true);

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
