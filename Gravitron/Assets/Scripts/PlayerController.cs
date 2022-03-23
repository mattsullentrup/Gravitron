using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 1100f;
    private Rigidbody playerRb;
    private bool launchAvailable = true;
    [SerializeField] private float laserWaitTime = 0.25f;
    [SerializeField] private float zBound = 4.8f;
    [SerializeField] private float xBound = 14f;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private Transform projectileSpawnPoint;
    
    void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Abstraction
        ConstrainPlayerPosition();
        Shoot();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    // Moves the player
    void PlayerMovement()
    {
        if (GameManager.Manager.gameOver == false)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 movement = playerSpeed * Time.fixedDeltaTime * new Vector3(horizontalInput, 0, verticalInput);
            playerRb.AddForce(movement);
        }
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GameManager.Manager.gameOver == false && launchAvailable == true)
        {
            // Launch a projectile from the player
            Instantiate(laserPrefab, projectileSpawnPoint.position, laserPrefab.transform.rotation);
            StartCoroutine(WaitToLaunch());
        }
    }

    IEnumerator WaitToLaunch()
    {
        launchAvailable = false;
        yield return new WaitForSeconds(laserWaitTime);
        launchAvailable = true;
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
