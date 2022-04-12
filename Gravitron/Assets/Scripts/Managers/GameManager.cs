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
    
    
    public bool gameOver;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject playerHealthThree;
    [SerializeField] private GameObject playerHealthTwo;
    [SerializeField] private GameObject playerHealthOne;
    [SerializeField] private GameObject healthUI;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject gameOverFirstButton;
    CanvasManager canvasManager;

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

        //gameOver = false;
        player = GameObject.Find("Player");
    }

    private void Start()
    {
        canvas = GameObject.Find("Canvas");
        
        healthUI = canvas.transform.GetChild(2).GetChild(3).gameObject;
        playerHealthThree = healthUI.transform.GetChild(0).gameObject;
        playerHealthTwo = healthUI.transform.GetChild(1).gameObject;
        playerHealthOne = healthUI.transform.GetChild(2).gameObject;
        gameOverFirstButton = canvas.transform.GetChild(3).GetChild(1).gameObject;
        canvasManager = CanvasManager.GetInstance();
        StartGame();
        //UpdateScore(0);
    }

    private void Update()
    {
        //Abstraction
        //GameOver();
        CheckPlayerHealth();
    }

    public void GameOver()
    {
        gameOver = true;
        canvasManager.SwitchCanvas(CanvasType.EndScreen);
        Destroy(player);
        StopAllCoroutines();

        
        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(gameOverFirstButton);
    }

    public void StartGame()
    {
        //canvasManager.SwitchCanvas(CanvasType.GameUI);
        gameOver = false;
        ScoreManager.ScoreManagerInstance.score = 0;
        ScoreManager.ScoreManagerInstance.UpdateScore(0);

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
