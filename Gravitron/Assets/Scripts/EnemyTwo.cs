using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwo : EnemyOne //Inheritance
{
    [SerializeField] private Vector3 minRotation;
    [SerializeField] private Vector3 maxRotation;
    [SerializeField] private float rotationSpeed;

    private void Start()
    {
        rotationSpeed = Random.Range(-15f, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        Explode();
        EnemyMovement();
    }

    public override void EnemyMovement() //polymorphism
    {
        transform.Translate(speed * Time.deltaTime * Vector3.back);

        Vector3 randomRotation = new Vector3(0, 0, Random.Range(minRotation.z, maxRotation.z));

        transform.Rotate((rotationSpeed * 20) * Time.deltaTime * randomRotation);
    }
}
