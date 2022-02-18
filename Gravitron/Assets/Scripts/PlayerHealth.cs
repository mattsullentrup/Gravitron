using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    #region Properties
    #endregion

    #region Initialisation methods
    #endregion

    #region Gameplay methods
    #endregion


    public int currentPlayerHealth;
    public bool hasPowerup = false;
    private PlayerController playerController;
    [SerializeField] private int healthInitial = 3;
    [SerializeField] private GameObject powerupIndicator;

    private void Awake()
    {
        // Initialiase the player's current health
        ResetHealth();
    }

    private void Start()
    {
        playerController = this.GetComponent<PlayerController>();
    }

    // Sets the player's current health back to its initial value
    public void ResetHealth()
    {
        // Initialise the player's current health
        currentPlayerHealth = healthInitial;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.Manager.gameOver == false)
        {
            if (other.gameObject.CompareTag("Powerup"))
            {
                hasPowerup = true;
                playerController.playerSpeed = 2000f;
                powerupIndicator.SetActive(true);
                other.gameObject.SetActive(false);
                StartCoroutine(PowerupCountdownRoutine());
            }
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.SetActive(false);
                currentPlayerHealth -= 1;
            }
            if (other.gameObject.CompareTag("Enemy Two"))
            {
                other.gameObject.SetActive(false);
                currentPlayerHealth -= 1;
            }
            if (other.gameObject.CompareTag("Asteroid"))
            {
                other.gameObject.SetActive(false);
                currentPlayerHealth -= 1;
            }

            IEnumerator PowerupCountdownRoutine()
            {
                yield return new WaitForSeconds(7);
                hasPowerup = false;
                powerupIndicator.SetActive(false);
                playerController.playerSpeed = 1100f;
            }
        }
    }
}
