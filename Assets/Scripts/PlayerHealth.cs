using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health the player can have
    public int currentHealth; // Current health value

    void Start()
    {
        // Initialize health to maximum at the start
        currentHealth = maxHealth;
        Debug.Log($"Player Health: {currentHealth}/{maxHealth}");
    }

    // Method to increase health
    public void IncreaseHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth; // Ensure health does not exceed the maximum
        }
        Debug.Log($"Health increased by {amount}. Current Health: {currentHealth}/{maxHealth}");
    }

    // Method to deal damage to the player
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"Player took {damage} damage. Current Health: {currentHealth}/{maxHealth}");

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    // Method to handle player death
    private void Die()
    {
        Debug.Log("Player has died!");
        // Implement additional death behavior here (e.g., reload level, show game over screen)
    }
}
