using UnityEngine;

public class HealthOrb : MonoBehaviour
{
    public int healthBoostAmount = 10; // Amount of health to increase

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.IncreaseHealth(healthBoostAmount);
                Debug.Log($"Health increased by {healthBoostAmount}");
            }

            Destroy(gameObject); // Remove the orb after collection
        }
    }
}