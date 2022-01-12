using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOne : MonoBehaviour
{
    public int enemyHealth;
    public float speed = 1.0f;
    public Rigidbody enemyRb;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        MoveDown();
        Explode();
    }

    // Update is called once per frame
    void Explode()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public virtual void MoveDown()
    {
        transform.Translate(Vector3.forward * -speed * Time.deltaTime);
    }
}
