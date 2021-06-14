using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;

    public GameObject destroyEffect;

    [SerializeField] bool enemyFang;


    private void Start()
    {
        Invoke("DestroyBullet", lifetime);
    }
    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if(hitInfo.collider != null)
        {
            if(hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
            if (hitInfo.collider.CompareTag("Player")&& enemyFang)
            {
                hitInfo.collider.GetComponent<Player>().TakeDamage(damage);
            }
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    public void DestroyBullet()
    {

        Destroy(gameObject);
    }
}
