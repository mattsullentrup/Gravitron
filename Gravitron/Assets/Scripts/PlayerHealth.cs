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
    //private PlayerController playerController;
    //private Rigidbody playerRb;
    [SerializeField] private int healthInitial = 3;
    [SerializeField] private GameObject powerupIndicator;
    private Vector3 startPosition;
    [SerializeField]  private float initialPlayerspeed = 1200f;

    private void Awake()
    {
        startPosition = transform.position;

        // Initialiase the player's current health
        currentPlayerHealth = healthInitial;
    }

    // Sets the player's current health back to its initial value
    public void ResetPlayer()
    {
        // Initialise the player's current health
        currentPlayerHealth = healthInitial;

        transform.position = startPosition;

        hasPowerup = false;
        powerupIndicator.SetActive(false);
        PlayerController.Instance.playerSpeed = initialPlayerspeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.Manager.gameOver == false)
        {
            if (other.gameObject.CompareTag("Powerup"))
            {
                hasPowerup = true;
                PlayerController.Instance.playerSpeed += 1000f;
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
                PlayerController.Instance.playerSpeed = initialPlayerspeed;
            }
        }
    }
}
