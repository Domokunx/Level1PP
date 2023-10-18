using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    
    public void SetMaxHealth(float hp)
    {
        healthBar.maxValue = hp;
        healthBar.value = hp;
    }
    
    public void SetHealth(float hp)
    {
        healthBar.value = hp;
    }

}
