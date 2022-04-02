using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; set; }

    public float playerSpeed = 1100f;
    private Rigidbody playerRb;
    private bool launchAvailable = true;
    [SerializeField] private float laserWaitTime = 0.25f;
    [SerializeField] private float zBound = 4.8f;
    [SerializeField] private float xBound = 14f;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private Transform projectileSpawnPoint;

    public InputAction fire;
    public InputAction move;

    private float movementX;
    private float movementY;

    PlayerControls controls;

    void Awake()
    {
        controls = new PlayerControls();

        playerRb = GetComponent<Rigidbody>();

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
        }

        //DontDestroyOnLoad(Instance);
    }

    void OnEnable()
    {
        move = controls.Player.Move;
        move.Enable();

        fire = controls.Player.Fire;
        fire.Enable();
        fire.performed += Fire;
    }

    void OnDisable()
    {
        move.Disable();
        fire.Disable();
    }

    private void Update()
    {
        //Abstraction
        ConstrainPlayerPosition();
        //Fire();
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    private void OnMove()
    {
        Vector2 moveDirection = move.ReadValue<Vector2>();

        movementX = moveDirection.x;
        movementY = moveDirection.y;

        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        playerRb.AddForce(playerSpeed * Time.deltaTime * movement);
        //playerRb.MovePosition(transform.position + (playerSpeed * Time.deltaTime * movement));
        //transform.Translate(playerSpeed * Time.deltaTime * movement);
    }

    private void Fire(InputAction.CallbackContext context)
    {
        if (GameManager.Manager.gameOver == false && launchAvailable == true)
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
