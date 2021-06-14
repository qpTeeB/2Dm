using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Rune")]
    public GameObject runeIcon;
    public GameObject wallEffect;

    public float speed;
    public Rigidbody2D rb;
    private MobileController mContr;
    public Animator anim;
    Vector2 Movement;
    public int health;
    public GameObject deathEffect;

    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public GameObject panel;
    public GameObject pause;
    public GameObject Js1;
    public GameObject Js2;

    private bool keyButtonPushed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        mContr = GameObject.FindGameObjectWithTag("Joystick").GetComponent<MobileController>();
    }
    void Update()
     {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            isDashButtonDown = true;
        }*/
        Movement.x = mContr.Horizontal();
        Movement.y = mContr.Vertical();



        anim.SetFloat("Horizontal", Movement.x);
        anim.SetFloat("Vertical", Movement.y);
        anim.SetFloat("Speed", Movement.sqrMagnitude);

        if(health <=0)
        {
            pause.SetActive(false);
            Js1.SetActive(false);
            Js2.SetActive(false);
            panel.SetActive(true);
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        // float moveInputX = Input.GetAxis("Horizontal");
        // float moveInputY = Input.GetAxis("Vertical");
        if(health > numOfHearts)
        {
            health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i< Mathf.RoundToInt(health))
            { 
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        rb.MovePosition(rb.position + Movement * speed * Time.fixedDeltaTime);

        //Vector2 Movement = new Vector3(mContr.Horizontal(), mContr.Vertical(), 0);
        //this.transform.position += Movement * speed * Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Rune"))
        {
            runeIcon.SetActive(true);
            Destroy(collision.gameObject);
        }
    }
    public void OnKeyButtonDown()
    {
        keyButtonPushed = !keyButtonPushed;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Gate")&& keyButtonPushed && runeIcon.activeInHierarchy)
        {
            Instantiate(wallEffect, collision.transform.position, Quaternion.identity);
            runeIcon.SetActive(false);
            collision.gameObject.SetActive(false);
            keyButtonPushed = false;
        }
    }

    public void TakeDamage(int damage)
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        health -= damage;
    }
}