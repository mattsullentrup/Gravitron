using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 100f;
    private float zBound = 5.5f;
    private float xBound = 10f;
    private Rigidbody playerRb;

    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private Transform projectileSpawnPoint;

    // Start is called before the first frame update
    void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Abstraction
        ConstrainPlayerPosition();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    // Moves the player
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * speed * Time.fixedDeltaTime;

        //playerRb.velocity = (transform.position + movement);
        playerRb.AddForce(movement);
    }

    private void Shoot()
    {
        // Launch a projectile from the player
        //Instantiate(laserPrefab, projectileSpawnPoint.position, laserPrefab.transform.rotation);

        GameObject laser = ObjectPooler.Instance.GetPooledObject("Laser");

        if (laser != null)
        {
            laser.transform.position = projectileSpawnPoint.position;
            laser.transform.rotation = laser.transform.rotation;
            laser.SetActive(true);
        }
    }

    // Prevent the player from leaving the screen
    void ConstrainPlayerPosition()
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Enemy Two"))
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Asteroid"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
