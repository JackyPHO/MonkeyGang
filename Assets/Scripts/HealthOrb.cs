using UnityEngine;

public class HealthOrb : MonoBehaviour
{
    public int healthIncreaseAmount = 25; // Amount of health to restore

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.IncreaseHealth(healthIncreaseAmount);
                Debug.Log($"Health orb collected! Restored {healthIncreaseAmount} health.");
            }

            Destroy(gameObject); // Remove the orb after collection
        }
    }
}
