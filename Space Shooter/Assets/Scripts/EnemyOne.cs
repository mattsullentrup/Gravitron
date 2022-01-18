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
    }

    // Update is called once per frame
    public void Explode()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public virtual void FlyDown()
    {
        Debug.Log("E1 move down");
        transform.Translate(speed * Time.deltaTime * Vector3.back);
    }

    private void Update()
    {
        FlyDown();
        Explode();
    }
}
