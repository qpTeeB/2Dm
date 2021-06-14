using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public float speed;
    public float normalSpeed;
    public int health;
    private Transform playerPos;
    public GameObject destroyEffect;
    public Animator anim;

    public int damage;
    private float stopTime;
    public float startStopTime;
    private Player player;
    private AddRoom room;

    private ScoreManager sm;


    private void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
        sm = FindObjectOfType<ScoreManager>();
        room = GetComponentInParent<AddRoom>();
    }

    private void Update()
    {
        if(stopTime <= 0)
        {
            speed = normalSpeed;
        }
        else
        {
            speed = 0;
            stopTime -= Time.deltaTime;
        }
        if (health <= 0)
        {
            anim.SetTrigger("ded");
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            //sm.Kill();
            Destroy(gameObject.GetComponent<CapsuleCollider2D>());
            Destroy(gameObject.GetComponent<CircleCollider2D>());
            Destroy(gameObject.GetComponent<Rigidbody2D>());
            Object.Destroy(gameObject, 0f);
            room.enemies.Remove(gameObject);
            //Destroy(gameObject);
            /*if (anim.GetCurrentAnimatorStateInfo(0).IsTag("ded"))
                {
                
            }*/
            
        }
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);

    }

    public void TakeDamage(int damage)
    {
        stopTime = startStopTime;
        health -= damage;
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(timeBtwAttack <= 0)
            {
                anim.SetTrigger("attack");
                player.TakeDamage(damage);
                timeBtwAttack = startTimeBtwAttack;
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
    }
    /*public void OnEnemyAttack()
    {
        player.TakeDamage(damage);
        timeBtwAttack = startTimeBtwAttack;
    }*/
}
