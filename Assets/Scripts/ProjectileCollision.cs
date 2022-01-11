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
            collision.gameObject.GetComponent<EnemyStats>().enemyHealth -= damage;
            //Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Debug.Log("Laser - Asteroid");
            collision.gameObject.GetComponent<AsteroidStats>().asteroidHealth -= damage;
            //Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
