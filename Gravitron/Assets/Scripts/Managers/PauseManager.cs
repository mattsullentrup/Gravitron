using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseManager : MonoBehaviour
{
    public static PauseManager pauseManagerInstance { get; set; }
    PlayerControls pauseAction;
    public static bool paused = false;
    private GameObject canvas;
    public GameObject pauseMenu;
    public GameObject pauseFirstButtton;

    private void Awake()
    {
        if (pauseManagerInstance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            pauseManagerInstance = this;
        }

        pauseAction = new PlayerControls();
    }

    private void OnEnable()
    {
        pauseAction.Enable();
        pauseAction.UI.Enable();
        PlayerController.controls.Enable();
    }

    private void OnDisable()
    {
        pauseAction.Disable();
        PlayerController.controls.Disable();
        pauseAction.UI.Disable();
    }

    private void Start()
    {
        pauseAction.Pause.PauseGame.performed += _ => DeterminePause();
        canvas = GameObject.Find("Canvas");
        pauseMenu = canvas.transform.GetChild(3).GetChild(0).gameObject;
        pauseFirstButtton = pauseMenu.transform.GetChild(4).gameObject;
    }

    private void DeterminePause()
    {
        if (paused)
            ResumeGame();
        else
            PauseGame();
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        paused = true;
        pauseMenu.SetActive(true);
        PlayerController.controls.Disable();
        pauseAction.UI.Enable();


        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(pauseFirstButtton);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        paused = false;
        pauseMenu.SetActive(false);
        pauseAction.UI.Disable();
        PlayerController.controls.Enable();
    }
}
