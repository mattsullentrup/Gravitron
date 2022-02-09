using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public int asteroidHealth;

    private void Update()
    {
        Explode();
    }

    private void Explode()
    {
        if (asteroidHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
