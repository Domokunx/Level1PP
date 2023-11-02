using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] float initialDrunkLevel;
    public float drunkLevel;
    public float maxDrunkLevel = 10f;
    public float maxHealth = 100f;
    public float currentHealth;
    public List<BottleScript.BottleType> inventory;

    public Slider healthBar;
    public Slider drunkBar;
    void Start()
    {
        drunkLevel = initialDrunkLevel;
        drunkBar.maxValue = 10;
        drunkBar.minValue = 0;
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
        inventory = new List<BottleScript.BottleType> ();

    }
    private void FixedUpdate()
    {
        if (currentHealth > 100)
        {
            currentHealth = 100;
            healthBar.value = currentHealth;
        }
        if (drunkLevel > maxDrunkLevel)
        {
            drunkLevel = maxDrunkLevel;
        }
        if (drunkLevel > 0)
        {
            drunkLevel -= 0.005f;
            drunkBar.value = drunkLevel;
        } else if (currentHealth > 0)
        {
            TakeDamage(0.1f);
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        print("Detected Collider");
        if (collision.CompareTag("Collectible"))
        {
            
            BottleScript.BottleType itemType = collision.gameObject.GetComponent<BottleScript>().itemType;
            print("we have collected a :" + itemType);

            if (itemType == BottleScript.BottleType.Beer)
            {
                drunkLevel += 4f;
            } else if (itemType == BottleScript.BottleType.Water)
            {
                if (drunkLevel >= 0f)
                {
                    drunkLevel -= 1f;
                }
                currentHealth += 25f;
            }

            inventory.Add(itemType);
            print("Inventory length:" + inventory.Count);
            Destroy(collision.gameObject);
        }
    }
}
