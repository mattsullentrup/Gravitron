using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidStats : MonoBehaviour
{
    public int asteroidHealth;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (asteroidHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
