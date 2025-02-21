using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider bar;
    public void SetMaxHealth (int health){
        bar.maxValue = health;
        bar.value = health;
    }
    public void SetHealth(int health)
    {
        bar.value = health;
    }
}
