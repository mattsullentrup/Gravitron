using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public static UIManager UIManagerInstance { get; set; }
    public GameObject optionsFirstButton, optionsClosedButton, mainMenuFirstButton;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameUI;

    private void Awake()
    {

        if (UIManagerInstance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            UIManagerInstance = this;
        }

        //DontDestroyOnLoad(UIManagerInstance);

    }

    public void GameScene()
    {
        gameUI.SetActive(true);
        mainMenu.SetActive(false);
        SceneManager.LoadScene("GameScene");
    }

    public void BackToMenu()
    {
        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(mainMenuFirstButton);

        GameManager.Manager.gameOver = true;
        GameManager.Manager.gameOverScreen.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void OpenOptions()
    {
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(optionsFirstButton);
    }

    public void CloseOptions()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(optionsClosedButton);
    }
}
