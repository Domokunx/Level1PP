using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrunkMeter : MonoBehaviour
{
    public Slider drunkMeterBar;

    public void SetMaxDrunkLevel(float maxDrunkLevel)
    {
        drunkMeterBar.maxValue = maxDrunkLevel;
        drunkMeterBar.value = maxDrunkLevel;
    }
    public void SetDrunkLevel(float DrunkLevel)
    {
        drunkMeterBar.value = DrunkLevel;
    }
}
