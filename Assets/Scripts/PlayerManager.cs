using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] float initialDrunkLevel;
    public float drunkLevel;
    public float maxHealth = 100f;
    public float currentHealth;

    public Slider healthBar;
    void Start()
    {
        drunkLevel = initialDrunkLevel;
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
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
}
