using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwo : EnemyOne //Inheritance
{
    //public int enemyTwoHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FlyDown();
        Explode();
    }

    public override void FlyDown() //polymorphism
    {
        Debug.Log("E2 move down");
        base.FlyDown();
    }
}
