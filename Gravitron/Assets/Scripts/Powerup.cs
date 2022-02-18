using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private Vector3 randomVectorRotation;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float rotationRangeX;
    [SerializeField] private float rotationRangeY;
    [SerializeField] private float rotationRangeZ;
    [SerializeField] private float lowerBound = -10;
    

    private void Start()
    {
        rotationSpeed = Random.Range(-30f, 30f);

        rotationRangeX = Random.Range(-10f, 10f);
        rotationRangeY = Random.Range(-10f, 10f);
        rotationRangeZ = Random.Range(-10f, 10f);

        randomVectorRotation = new Vector3(rotationRangeX, rotationRangeY, rotationRangeZ);
    }

    private void Update()
    {
        PowerUpMovement();
        DestroyOutOfBounds();
    }

    private void PowerUpMovement()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.back, Space.World);

        transform.Rotate(rotationSpeed * Time.deltaTime * randomVectorRotation);
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
