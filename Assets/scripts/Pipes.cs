using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float speed = 5f;
    private float leftedge;

    private void Start()//38dak
    {
        leftedge = Camera.main.ScreenToWorldPoint(Vector3.zero).x-1;//screen dısında yok olması için.
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x<leftedge)
        {
            Destroy(gameObject);
        }
        
        
    }
}
