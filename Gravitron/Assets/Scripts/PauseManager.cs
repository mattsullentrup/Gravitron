using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{

    PauseAction action;
    public static bool paused = false;
    public GameObject pauseMenu;

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
        //StopAllCoroutines();
        Time.timeScale = 0;
        paused = true;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        paused = false;
        pauseMenu.SetActive(false);
        //StartCoroutine(SpawnManager.Instance.SpawnEnemyOne());
        //StartCoroutine(SpawnManager.Instance.SpawnEnemyTwo());
        //StartCoroutine(SpawnManager.Instance.SpawnPowerup());
        //StartCoroutine(SpawnManager.Instance.SpawnAsteroid());
    }
}
