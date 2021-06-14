using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GunType gunType;
    public float offset;
    public GameObject arrow;
    public Joystick joystick;
    public Transform shootPoint;

    private float timeBtwShots;
    public float startTimeBtwShots;

    private Player player;
    private Vector3 difference;
    private float rotZ;

    public enum GunType {Default, Enemy}

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void Update()
    {

        //difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        if(gunType == GunType.Default)
        {
            if (Mathf.Abs(joystick.Horizontal) > 0.3f || Mathf.Abs(joystick.Vertical) > 0.3f)
            {
                rotZ = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg;
            }
        }
        else if (gunType == GunType.Enemy)
        {
            difference = player.transform.position - transform.position;
            rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        }

        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if(timeBtwShots <= 0)
        { 
            if(gunType == GunType.Enemy)
            {
                Shoot();
            }
            if(joystick.Horizontal !=0 || joystick.Vertical !=0)
            {
                Shoot();
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
    public void Shoot()
    {
        Instantiate(arrow, shootPoint.position, shootPoint.rotation);
        timeBtwShots = startTimeBtwShots;
    }
}
