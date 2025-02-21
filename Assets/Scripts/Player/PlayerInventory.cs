using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public HealthBar healthBar;
    public int maxHealth = 100;
    public int curentHealth;
    public int stoneCount;
    public int woodCount;

void Start() {
curentHealth = maxHealth;
healthBar.SetMaxHealth(maxHealth);
}
public void TakeDamage(int damage) {
curentHealth -= damage; 
healthBar.SetHealth(curentHealth);
}
   public  void IncrementStone()
    {
        stoneCount++;
    }
    public void IncrementWood()
    {
        woodCount++;
    }

}
