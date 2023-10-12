using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private float maxHealth = 100f;
    private Slider healthBar;
    void Start()
    {
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = PlayerManager.health;
    }
}
