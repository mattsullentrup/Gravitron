using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwo : EnemyOne //Inheritance
{
    //public int enemyTwoHealth;
    [SerializeField] private float xSpeed;

    //private float spawnRangeX = 10;
    //private float spawnPosZ = 8;
    //private float spawnPosY = 1.5f;

    //private void Awake()
    //{
    //    Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, spawnPosZ);

    //    gameObject.transform.position = spawnPos;
    //}



    //float frequency = 10.0f; // Speed of sine movement
    //float magnitude = 0.5f; //  Size of sine movement

    //Vector3 pos;
    //Vector3 axis;

    //private void Awake()
    //{
    //    pos = transform.position;
    //    axis = transform.right;

    //}

    //Vector3 back = new Vector3(transform.position.x + 1, 0, -1); //assign it whatever value you want one edge of the movement to be
    //Vector3 forth = new Vector3(transform.position.x -1, 0, -1); //again, assign whatever the other edge is supposed to be
    //float phase = 0;
    ////float speed = 1; //adjust to anything that results in the speed u want
    //float phaseDirection = 1; //this is just to make the code less "ify" =D

    void Start()
    {
        //StartCoroutine(MoveRight());
    }

    // Update is called once per frame
    void Update()
    {
        Explode();
        FlyDown();
        
    }

    public override void FlyDown() //polymorphism
    {
        transform.Translate(speed * Time.deltaTime * Vector3.back);

        //transform.position = new Vector3(Mathf.PingPong(Time.time * xSpeed, 3), transform.position.y, transform.position.z);

        //Vector3 myVector = new Vector3(Mathf.PingPong(Time.time * xSpeed, 1), 0, -1);
        //transform.Translate(speed * Time.deltaTime * myVector);

        //IEnumerator MoveRight()
        //{
        //    transform.Translate(speed * Time.deltaTime * Vector3.right);
        //    yield return new WaitForSeconds(1);
        //}

        //IEnumerator MoveLeft()
        //{
        //    transform.Translate(speed * Time.deltaTime * Vector3.left);
        //    yield return new WaitForSeconds(1);
        //}

        //GameObject enemyTwo = ObjectPooler.Instance.GetPooledObject("Enemy Two");
        //if (this.gameObject != null)
        //{
        //    pos += Vector3.back * Time.deltaTime * speed;
        //    transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
        //}

        //transform.position = Vector3.Lerp(back, forth, phase); //phase determines (in percent, basically) where on the line between the points "back" and "forth" you want the enemy to be placed, so if we gradually increase/decrease the variable, it makes the enemy move between those two points.
        //phase += Time.deltaTime * speed * phaseDirection; //subtracts from 1 to zero when phaseDirection is negative, adds from zero to one when phaseDirection is positive.
        //if (phase >= 1 || phase <= 0) phaseDirection *= -1; //flip the sign to flip direction

    }
}
