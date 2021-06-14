using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    [Header("Door")]
    public GameObject[] doors;
    public GameObject wallEffect;
    public GameObject gate;

    [Header("Enemies")]
    public GameObject[] enemyTypes;
    public Transform[] enemySpawner;

    [HideInInspector] public List<GameObject> enemies;

    private RoomVariants variants;
    private bool spawned;
    private bool doorsDestroyed;

    private void Start()
    {
        variants = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomVariants>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !spawned)
        {
            spawned = true;

            foreach(Transform spawner in enemySpawner)
            {
                int rand = Random.Range(0, 10);
                if (rand < 9)
                {
                    GameObject enemyType = enemyTypes[Random.Range(0, enemyTypes.Length)];
                    GameObject enemy = Instantiate(enemyType, spawner.position, Quaternion.identity) as GameObject;
                    enemy.transform.parent = transform;
                    enemies.Add(enemy);
                }
            }
            StartCoroutine(CheckEnemies());
        }
    }
    IEnumerator CheckEnemies()
    {
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => enemies.Count == 0);
        DestroyDoors();
    }
    public void DestroyDoors()
    {
        foreach(GameObject door in doors)
        {
            if (door != null && door.transform.childCount != 0)
            {
                Instantiate(wallEffect, door.transform.position, Quaternion.identity);
                Destroy(door);
            }
        }
        doorsDestroyed = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(doorsDestroyed && collision.CompareTag("Door"))
        {
            Destroy(collision.gameObject);
        }
    }
}
