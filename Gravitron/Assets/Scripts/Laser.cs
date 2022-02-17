using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float topBound = 20;
    private Rigidbody laserRb;

    public int damage;
    [SerializeField] private float laserSpeed = 40.0f;

    private void Start()
    {
        laserRb = GetComponent<Rigidbody>();        
    }

    private void Update()
    {
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);

        LaserBoundary();
    }

    private void FixedUpdate()
    {
        laserRb.MovePosition(transform.position + laserSpeed * Time.fixedDeltaTime * Vector3.forward);
    }

    void LaserBoundary()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyOne>().enemyHealth -= damage;
            gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Enemy Two"))
        {
            collision.gameObject.GetComponent<EnemyTwo>().enemyHealth -= damage;
            gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            collision.gameObject.GetComponent<Asteroid>().asteroidHealth -= damage;
            gameObject.SetActive(false);
        }
    }
}
