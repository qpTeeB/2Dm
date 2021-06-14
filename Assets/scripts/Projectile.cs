﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector2 target;
    public float speed;

    private void Start()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        
        if(Vector2.Distance(transform.position, target)< 0.2f)
        {
            Destroy(gameObject);
        }
    }
}
