using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public int asteroidHealth;
    private Vector3 randomRotation;
    [SerializeField] private float speed = 1f;
    [SerializeField] private int pointValue;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float rotationRangeX;
    [SerializeField] private float rotationRangeY;
    [SerializeField] private float rotationRangeZ;
    [SerializeField] private float lowerBound = -10;

    private void Start()
    {
        rotationSpeed = Random.Range(-150f, 150f);

        rotationRangeX = Random.Range(-1f, 1f);
        rotationRangeY = Random.Range(-1f, 1f);
        rotationRangeZ = Random.Range(-1f, 1f);

        randomRotation = new Vector3(rotationRangeX, rotationRangeY, rotationRangeZ);
    }

    private void Update()
    {
        Explode();
        AsteroidMovement();
        DestroyOutOfBounds();
    }

    private void Explode()
    {
        if (asteroidHealth <= 0)
        {
            Destroy(gameObject);
            ScoreManager.ScoreManagerInstance.UpdateScore(pointValue);
        }
    }

    private void AsteroidMovement()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.back, Space.World);
        transform.Rotate(Time.deltaTime * rotationSpeed * randomRotation);
    }

    private void DestroyOutOfBounds()
    {
        // If object goes past the player's view in the game, remove that object
        if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
        }
    }
}
