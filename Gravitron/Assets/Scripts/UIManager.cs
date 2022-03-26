using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //public GameObject mainMenuScreen;
    //public GameObject gameOverScreen;
    //public GameObject gameUI;


    //private void Start()
    //{
    //    //mainMenuScreen = GameObject.FindWithTag("Main Menu Screen");
    //    //gameOverScreen = GameObject.Find("Game Over");
    //    //gameUI = GameObject.Find("Game UI");

        
    //}

    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    

    //private void Update()
    //{
    //    CheckScene();
    //}

    //private void CheckScene()
    //{
    //    Scene scene = SceneManager.GetActiveScene();

    //    // here you can use scene.buildIndex or scene.name to check which scene was loaded
    //    if (scene.name == "MainMenu")
    //    {
    //        //mainMenuScreen.SetActive(true);
    //        gameOverScreen.SetActive(false);
    //        gameUI.SetActive(false);
    //    }

    //    else if (scene.name == "GameScene" && GameManager.Manager.gameOver == true)
    //    {

    //        mainMenuScreen.SetActive(false);
    //        gameOverScreen.SetActive(true);
    //        gameUI.SetActive(true);
    //    }
    //    else
    //    {
    //        gameOverScreen.SetActive(false);
    //        mainMenuScreen.SetActive(false);
    //        gameUI.SetActive(true);
    //    }
    //}
}
