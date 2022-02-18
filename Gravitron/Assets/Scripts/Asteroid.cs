using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public int asteroidHealth;

    [SerializeField] private float speed = 1f;
    [SerializeField] private int pointValue;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private float rotationRangeX;
    [SerializeField] private float rotationRangeY;
    [SerializeField] private float rotationRangeZ;

    public Vector3 randomRotation;

    private GameManager gameManager;

    private void Start()
    {
        rotationSpeed = Random.Range(-150f, 150f);

        rotationRangeX = Random.Range(-1f, 1f);
        rotationRangeY = Random.Range(-1f, 1f);
        rotationRangeZ = Random.Range(-1f, 1f);

        randomRotation = new Vector3(rotationRangeX, rotationRangeY, rotationRangeZ);

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void Update()
    {
        Explode();
        AsteroidMovement();
    }

    private void Explode()
    {
        if (asteroidHealth <= 0)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
        }
    }

    private void AsteroidMovement()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.back, Space.World);
        transform.Rotate(Time.deltaTime * rotationSpeed * randomRotation);

    }
}
