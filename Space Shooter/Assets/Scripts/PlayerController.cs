using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 1100f;
    private float zBound = 4.8f;
    private float xBound = 14f;
    private Rigidbody playerRb;

    [SerializeField] private GameObject powerupIndicator;
    [SerializeField] private bool hasPowerup = false;

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

        Vector3 movement = speed * Time.fixedDeltaTime * new Vector3(horizontalInput, 0, verticalInput);

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
            laser.transform.SetPositionAndRotation(projectileSpawnPoint.position, laser.transform.rotation);
            laser.SetActive(true);
        }
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            hasPowerup = true;
            speed = 2000f;
            powerupIndicator.gameObject.SetActive(true);
            other.gameObject.SetActive(false);
            StartCoroutine(PowerupCountdownRoutine());
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

        IEnumerator PowerupCountdownRoutine()
        {
            yield return new WaitForSeconds(7);
            hasPowerup = false;
            powerupIndicator.gameObject.SetActive(false);
            speed = 1100f;
        }
    }
}
