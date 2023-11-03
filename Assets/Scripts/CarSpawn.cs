using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour
{
    public GameObject car;
    public CarControl.Direction spawnDir;
    private float timer;

    private void Start()
    {
        timer = Random.Range(2f, 5f);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnCar();
            timer = Random.Range(4f, 10f);
            //Debug.Log(targetTime);
        }
    }

    void SpawnCar()
    {
        car.GetComponent<CarControl>().dir = spawnDir;
        Instantiate(car, transform.position, Quaternion.identity);
    }
}
