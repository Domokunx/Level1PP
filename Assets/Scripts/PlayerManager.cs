using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    private GameObject player;
    [SerializeField] float initialDrunkLevel;
    public float drunkLevel;
    public float maxHealth = 100f;
    public float currentHealth;
    public HealthBar healthBar;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        drunkLevel = initialDrunkLevel;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    public void Heal(float health)
    {
        currentHealth += health;
        healthBar.SetHealth(currentHealth);
    }
    private void FixedUpdate()
    {
        if (currentHealth > 100)
        {
            currentHealth = 100;
            healthBar.SetHealth(currentHealth);
        }
        if (drunkLevel > 0)
        {
            drunkLevel -= 0.001f;
        } else if (currentHealth > 0)
        {
            TakeDamage(0.2f);
        } else
        {
            Dead();
        }
        //print("\n health: " + currentHealth + " drunkLevel: " + drunkLevel);
    }
    private void Dead()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
