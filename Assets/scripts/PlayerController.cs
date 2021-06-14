using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    //private bool isDashButtonDown;
    //public float dashAmount;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   /* private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isDashButtonDown = true;
        }
    }*/
    private void FixedUpdate()
    {
        float moveInputX = Input.GetAxis("Horizontal");
        float moveInputY = Input.GetAxis("Vertical");

        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        this.transform.position += Movement * speed * Time.deltaTime;

/*           доделать деш
        if (isDashButtonDown)
        {
            rb.MovePosition(this.transform.position + Movement * dashAmount);
            isDashButtonDown = false;
        }
*/
    }
}
