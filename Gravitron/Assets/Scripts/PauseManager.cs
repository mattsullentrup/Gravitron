using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseManager : MonoBehaviour
{

    PauseAction action;
    public static bool paused = false;
    public GameObject canvas;
    public GameObject pauseMenu;
    public GameObject pauseFirstButtton;

    private void Awake()
    {
        action = new PauseAction();
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    private void Start()
    {
        action.Pause.PauseGame.performed += _ => DeterminePause();
        canvas = GameObject.Find("Canvas");
        pauseMenu = canvas.transform.GetChild(2).GetChild(0).gameObject;
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
    }
}
