using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOne : MonoBehaviour
{
    public int enemyHealth;
    [SerializeField] protected float speed = 1.0f;
    private float randomX;
    private Vector3 directionToFace;
    private Quaternion rotation;

    protected GameManager gameManager;

    [SerializeField] protected int pointValue;

    private void Start()
    {
        randomX = Random.Range(-0.5f, 0.5f);
        directionToFace = new Vector3(randomX, 0, -1);
        rotation = Quaternion.LookRotation(-directionToFace, Vector3.up);

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void Update()
    {
        Explode();
        EnemyMovement();
        transform.rotation = rotation;
    }

    public void Explode()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
        }
    }

    public virtual void EnemyMovement()
    {
        transform.Translate(speed * Time.deltaTime * directionToFace, Space.World);
    }
}
