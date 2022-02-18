using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 1100f;
    [SerializeField] private float zBound = 4.8f;
    [SerializeField] private float xBound = 14f;
    private Rigidbody playerRb;
    private GameManager gameManager;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private Transform projectileSpawnPoint;
    
    void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void Update()
    {
        //Abstraction
        ConstrainPlayerPosition();

        if (gameManager.gameOver == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }
        }
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    // Moves the player
    void PlayerMovement()
    {
        if (gameManager.gameOver == false)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 movement = playerSpeed * Time.fixedDeltaTime * new Vector3(horizontalInput, 0, verticalInput);
            playerRb.AddForce(movement);
        }
    }

    private void Shoot()
    {
        // Launch a projectile from the player
        Instantiate(laserPrefab, projectileSpawnPoint.position, laserPrefab.transform.rotation);
        //transform.Translate(laserSpeed * Time.deltaTime * Vector3.forward);
    }

    // Prevent the player from leaving the screen
    void ConstrainPlayerPosition() //Abstraction
    {
        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }

        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }

        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }
    }

    
}
