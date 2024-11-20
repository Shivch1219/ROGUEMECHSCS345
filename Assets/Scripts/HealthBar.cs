using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform greenBar; // Assign the Green Bar in the Inspector
    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // Set full health at start
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Prevent health from going below zero

        // Update the green bar's scale based on current health
        if (greenBar != null)
        {
            greenBar.localScale = new Vector3(currentHealth / maxHealth, 1, 1);
        }

        // If health is zero, destroy the enemy
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
