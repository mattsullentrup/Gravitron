using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    public int damage;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Laser - Enemy");
            collision.gameObject.GetComponent<EnemyOne>().enemyHealth -= damage;
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy Two"))
        {
            Debug.Log("Laser - Enemy");
            collision.gameObject.GetComponent<EnemyTwo>().enemyHealth -= damage;
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Debug.Log("Laser - Asteroid");
            collision.gameObject.GetComponent<Asteroid>().asteroidHealth -= damage;
            Destroy(gameObject);
        }
    }
}
