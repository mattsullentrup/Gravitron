using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOne : MonoBehaviour
{
    public int enemyHealth;
    public float speed = 1.0f;

    private void Update()
    {
        Explode();
        FlyDown();
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

    public virtual void FlyDown()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.back);
    }
}
