using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point1 : MonoBehaviour
{
    public Enemy enemy;
    private SpawnerUpg spawner;

    private void Start()
    {
        spawner = FindObjectOfType<SpawnerUpg>();
        Instantiate(enemy, transform.position, transform.rotation);
        enemy.health = Mathf.RoundToInt(spawner.enemyHealth);
        enemy.damage = Mathf.RoundToInt(spawner.enemyDamage);
    }
}
