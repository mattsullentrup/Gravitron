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
    private Rigidbody playerRb;
    [SerializeField] private int healthInitial = 3;
    [SerializeField] private GameObject powerupIndicator;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();

        // Initialiase the player's current health
        currentPlayerHealth = healthInitial;
    }

    private void Start()
    {
        playerController = this.GetComponent<PlayerController>();
    }

    // Sets the player's current health back to its initial value
    public void ResetPlayer()
    {
        // Initialise the player's current health
        currentPlayerHealth = healthInitial;

        playerRb.position = new Vector3(0, 1.7f, -4.5f);

        hasPowerup = false;
        powerupIndicator.SetActive(false);
        playerController.playerSpeed = 5f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.Manager.gameOver == false)
        {
            if (other.gameObject.CompareTag("Powerup"))
            {
                hasPowerup = true;
                playerController.playerSpeed = 10f;
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
                playerController.playerSpeed = 5f;
            }
        }
    }
}
