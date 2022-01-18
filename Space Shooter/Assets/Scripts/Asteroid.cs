using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public int asteroidHealth;
    public Rigidbody asteroidRb;

    // Start is called before the first frame update
    void Start()
    {
        asteroidRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
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
}
