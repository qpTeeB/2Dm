using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemy1;
    public Transform[] spawnSpots;
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;

    public float decreaseTime;
    public float minTime;

    public float enemyHealth;
    public float increaseHealth;
    public float enemyDamage;
    public float increaseDamage;

    private void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;
    }
    private void Update()
    {
        enemyDamage += Time.deltaTime * increaseDamage;
        enemyHealth += Time.deltaTime * increaseHealth;

        if (timeBtwSpawns <= 0)
        {
            int randPos = Random.Range(0, spawnSpots.Length - 1);
            Instantiate(enemy, spawnSpots[randPos].position, Quaternion.identity);
            Instantiate(enemy1, spawnSpots[randPos].position, Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawns;
        } else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}
