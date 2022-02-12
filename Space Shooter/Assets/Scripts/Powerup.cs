using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float rotationSpeed;
    //[SerializeField] private Vector3 minRotation;
    //[SerializeField] private Vector3 maxRotation;

    [SerializeField] private float rotationRangeX;
    [SerializeField] private float rotationRangeY;
    [SerializeField] private float rotationRangeZ;

    public Vector3 randomVectorRotation;

    //public Quaternion randomQuaternionRotation;

    //public Quaternion quaternionRotation;

    //public Vector3 vectorRotation;

    private void Start()
    {
        rotationSpeed = Random.Range(-30f, 30f);

        rotationRangeX = Random.Range(-10f, 10f);
        rotationRangeY = Random.Range(-10f, 10f);
        rotationRangeZ = Random.Range(-10f, 10f);

        randomVectorRotation = new Vector3(rotationRangeX, rotationRangeY, rotationRangeZ);

        //randomQuaternionRotation = Quaternion.Euler(Random.Range(minRotation.x, maxRotation.x),
        //    Random.Range(minRotation.y, maxRotation.y),
        //    Random.Range(minRotation.z, maxRotation.z));

        //quaternionRotation = Quaternion.Euler(rotationRangeX, rotationRangeY, rotationRangeZ);

        //vectorRotation = Quaternion.Euler(rotationRangeX, rotationRangeY, rotationRangeZ) * randomVectorRotation;
    }

    private void Update()
    {
        PowerUpMovement();
    }

    private void PowerUpMovement()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.back, Space.World);

        transform.Rotate(rotationSpeed * Time.deltaTime * randomVectorRotation);

    }
}
