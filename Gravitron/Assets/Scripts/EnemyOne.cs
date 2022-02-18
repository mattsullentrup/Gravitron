using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOne : MonoBehaviour
{
    public int enemyHealth;
    private float randomX;
    private Vector3 directionToFace;
    private Quaternion rotation;
    private float lowerBound = -10;
    [SerializeField] protected float speed = 1.0f;
    [SerializeField] protected int pointValue;

    private void Start()
    {
        randomX = Random.Range(-0.5f, 0.5f);
        directionToFace = new Vector3(randomX, 0, -1);
        rotation = Quaternion.LookRotation(-directionToFace, Vector3.up);
    }

    private void Update()
    {
        Explode();
        EnemyMovement();
        DestroyOutOfBounds();
        transform.rotation = rotation;
    }

    public void Explode()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
            GameManager.Manager.UpdateScore(pointValue);
        }
    }

    public virtual void EnemyMovement()
    {
        transform.Translate(speed * Time.deltaTime * directionToFace, Space.World);
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
