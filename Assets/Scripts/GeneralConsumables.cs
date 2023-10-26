using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralConsumables : MonoBehaviour
{

    public GameObject[] consumables;
    public GameObject[] spawnPoints;
    float consumableSpawnTimer = 5f;

    public void spawnConsumable(GameObject item, Transform spawnpos)
    {
        Instantiate(item, spawnpos);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(consumableSpawnRoutine());
    }

    public IEnumerator consumableSpawnRoutine()
    {
        
        int nextSpawnLocation = Random.Range(0, spawnPoints.Length);
        int nextSpawnConsumable = Random.Range(0, consumables.Length);
        spawnConsumable(consumables[nextSpawnConsumable], spawnPoints[nextSpawnLocation].transform);
        yield return new WaitForSeconds(consumableSpawnTimer);
        
        if (!GameManager.gameOver)
        {
            StartCoroutine(consumableSpawnRoutine());
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
