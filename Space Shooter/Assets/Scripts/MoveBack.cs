using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBack : MonoBehaviour
{
    public float speed = 1f;

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.back);
    }
}
