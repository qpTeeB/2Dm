﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public Direction direction;
    public GameObject block;

    public enum Direction
    {
        Top,
        Bottom,
        Left,
        Right,
        None
    }

    private RoomVariants variants;
    private int rand;
    private bool spawned = false;
    private float waitTime = 2f;

    private void Start()
    {
        variants = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomVariants>();
        Destroy(gameObject, waitTime);
        Invoke("Spawn", 0.2f);
    }
    public void Spawn()
    {
        if(!spawned)
        {
            if(direction == Direction.Top)
            {
                rand = Random.Range(0, variants.topRooms.Length);
                Instantiate(variants.topRooms[rand], transform.position, variants.topRooms[rand].transform.rotation);
            }
             if (direction == Direction.Bottom)
            {
                rand = Random.Range(0, variants.bottomRooms.Length);
                Instantiate(variants.bottomRooms[rand], transform.position, variants.bottomRooms[rand].transform.rotation);
            }
             if (direction == Direction.Right)
            {
                rand = Random.Range(0, variants.rightRooms.Length);
                Instantiate(variants.rightRooms[rand], transform.position, variants.rightRooms[rand].transform.rotation);
            }
             if (direction == Direction.Left)
            {
                rand = Random.Range(0, variants.leftRooms.Length);
                Instantiate(variants.leftRooms[rand], transform.position, variants.leftRooms[rand].transform.rotation);
            }
            spawned = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("RoomPoint")&& collision.GetComponent<RoomSpawner>().spawned)
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("Block"))
        {
            Instantiate(block, transform.GetChild(1).position, Quaternion.identity);
            Instantiate(block, transform.GetChild(2).position, Quaternion.identity);
            Instantiate(block, transform.GetChild(3).position, Quaternion.identity);
            Instantiate(block, transform.GetChild(4).position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
