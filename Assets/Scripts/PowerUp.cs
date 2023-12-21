using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float speedBoost = 20f; // Adjust the boost value as needed

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Apply power-up effect to the player
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.ApplySpeedBoost(speedBoost);
            }

            // Destroy the power-up GameObject
            Destroy(gameObject);
        }
    }
}

