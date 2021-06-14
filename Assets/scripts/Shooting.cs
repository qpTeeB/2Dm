using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Shooting : MonoBehaviour
{
    private Transform playerPos;
    public GameObject shot;

    public float arrowForce;

    private void Start()
    {
        playerPos = GetComponent<Transform>();
    }
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject arrow = Instantiate(shot, playerPos.position, transform.rotation);
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.AddForce(playerPos.up * arrowForce, ForceMode2D.Impulse);
    }
}
