using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralConsumables : MonoBehaviour
{

    public GameObject[] consumables;
    public Transform[] spawnPoints;
    float consumableSpawnTimer = 2f;
    float nextSpawnTime;

    public void spawnConsumable(GameObject item, Transform spawnpos)
    {
        Instantiate(item, spawnpos.position, spawnpos.rotation);
    }
    // Might be Unnecessary
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        nextSpawnTime = Time.fixedTime;
    }

    private void Update()
    {
        if (nextSpawnTime <= Time.fixedTime)
        {
            int nextSpawnLocation = Random.Range(0, spawnPoints.Length);
            int nextSpawnConsumable = Random.Range(0, consumables.Length);
            spawnConsumable(consumables[nextSpawnConsumable], spawnPoints[nextSpawnLocation]);
            nextSpawnTime += consumableSpawnTimer;
        }
    }
}
