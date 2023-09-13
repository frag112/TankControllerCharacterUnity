using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    public int Health { get; set; }
    public int maxHealth;
    public int currentHealth;

    public void TakeDamage(int damage = 5)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) Death();
    }
    public void Death()
    {
        print("you dead!");
    }
}
