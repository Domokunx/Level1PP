using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] float initialDrunkLevel;
    public float drunkLevel;
    public float maxHealth = 100f;
    public float currentHealth;
    public List<string> inventory;

    public Slider healthBar;
    void Start()
    {
        drunkLevel = initialDrunkLevel;
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
        inventory = new List<string>();

    }
    private void FixedUpdate()
    {
        if (currentHealth > 100)
        {
            currentHealth = 100;
            healthBar.value = currentHealth;
        }
        if (drunkLevel > 0)
        {
            drunkLevel -= 0.001f;
        }
        else if (currentHealth > 0)
        {
            TakeDamage(0.2f);
        }
        //print("\n health: " + currentHealth + " drunkLevel: " + drunkLevel);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;
    }
    public void Heal(float health)
    {
        currentHealth += health;
        healthBar.value = health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Collectible"))
        {
            string itemType = collision.gameObject.GetComponent<BottleScript>().itemType;
            print("we have collected a :"+ itemType);

            inventory.Add(itemType);
            print("Inventory length:"+ inventory.Count);
            Destroy(collision.gameObject);
        }
    }
}
