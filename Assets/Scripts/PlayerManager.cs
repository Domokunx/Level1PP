using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    private GameObject player;
    [SerializeField] float initialDrunkLevel;
    public float drunkLevel;
    private float health;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        drunkLevel = initialDrunkLevel;
        health = 100f;
    }

    private void FixedUpdate()
    {
        if (drunkLevel > 0)
        {
            drunkLevel -= 0.1f;
        } else if (health > 0)
        {
            health -= 0.2f;
        } else
        {
            Dead();
        }
        print("\n health: " + health + " drunkLevel: " + drunkLevel);
    }
    private void Dead()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
