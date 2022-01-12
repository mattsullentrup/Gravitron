using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public int asteroidHealth;
    protected Rigidbody asteroidRb;
    [SerializeField] private float speed = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        asteroidRb = GetComponent<Rigidbody>();
        MoveDown();
        Explode();
    }

    // Update is called once per frame
    void Explode()
    {
        if (asteroidHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void MoveDown()
    {
        transform.Translate(Vector3.forward * -speed * Time.deltaTime);
    }
}
