using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[System.Serializable]

public class GameManager : MonoBehaviour
{
    public static GameManager Manager { get; private set; } //Encapsulation
    //public GameObject titleScreen;
    public TMPro.TMP_Text scoreText;
    //public TMPro.TMP_Text gameOverText;
    //public Button restartButton;
    public bool gameOver;
    public GameObject playerHealthThree;
    public GameObject playerHealthTwo;
    public GameObject playerHealthOne;
    public GameObject healthUI;
    private int score;
    private GameObject player;

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

    private void GameOver()
    {
        if (player.GetComponent<PlayerHealth>().currentPlayerHealth <= 0)
        {
            gameOver = true;
            //restartButton.gameObject.SetActive(true);
            //gameOverText.gameObject.SetActive(true);
            gameOverScreen.SetActive(true);
            player.SetActive(false);
            StopAllCoroutines();
        }
    }

    public void StartGame()
    {
        player.SetActive(true);
        gameOver = false;
        score = 0;
        UpdateScore(0);
        //titleScreen.SetActive(false);
        //scoreText.gameObject.SetActive(true);
        //healthUI.SetActive(true);
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
