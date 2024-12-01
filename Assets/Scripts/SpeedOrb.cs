using UnityEngine;

public class SpeedOrb : MonoBehaviour
{
    public float speedBoostAmount = 2.0f; // Speed boost value
    public float duration = 5.0f; // Duration of the speed boost in seconds

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.IncreaseSpeed(speedBoostAmount, duration);
                Debug.Log($"Speed increased by {speedBoostAmount} for {duration} seconds.");
            }

            Destroy(gameObject); // Remove the orb after collection
        }
    }
}
