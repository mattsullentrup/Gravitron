using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOne : MonoBehaviour
{
    public int enemyHealth;
    public float speed = 1.0f;

    public float randomX;
    public Vector3 directionToFace;

    public Quaternion rotation;

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

        Debug.DrawRay(transform.position, directionToFace, Color.green);

        transform.rotation = rotation;
    }

    // Update is called once per frame
    public void Explode()
    {
        if (enemyHealth <= 0)
        {
            gameObject.SetActive(false);
            enemyHealth = 1;
        }
    }

    public virtual void EnemyMovement()
    {
        transform.Translate(speed * Time.deltaTime * directionToFace, Space.World);
    }
}
