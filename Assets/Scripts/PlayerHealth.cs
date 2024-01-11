using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 3;
    public float damageCooldown = 1f; // Cooldown time in seconds
    public float blinkDuration = 0.2f; // Duration of each blink
    public AudioClip gameOverSound;

    private float currentCooldown; // Timer to track cooldown
    private bool canTakeDamage = true; // Flag to check if damage can be taken

    public SpriteRenderer playerSr;
    public PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        currentCooldown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Update cooldown timer
        if (!canTakeDamage)
        {
            currentCooldown -= Time.deltaTime;
            if (currentCooldown <= 0f && health > 0)
            {
                canTakeDamage = true;
                StopCoroutine(BlinkPlayer());
                playerSr.enabled = true; // Make sure player is visible after blinking
            }
        }
    }

    public void TakeDamage(int amount)
    {
        // Check if damage can be taken based on cooldown
        if (canTakeDamage)
        {
            health -= amount;
            if (health <= 0)
            {
                playerSr.enabled = false;
                playerMovement.enabled = false;
                AudioSource.PlayClipAtPoint(gameOverSound, transform.position);
            }

            // Set cooldown
            canTakeDamage = false;
            currentCooldown = damageCooldown;


            // Start blinking coroutine
            if (health > 0)
            {
                StartCoroutine(BlinkPlayer());
            }
        }
    }

    IEnumerator BlinkPlayer()
    {
        while (!canTakeDamage && health>0)
        {
            playerSr.enabled = !playerSr.enabled; // Toggle visibility
            yield return new WaitForSeconds(blinkDuration);
        }
    }
}
