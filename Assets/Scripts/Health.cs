using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public RectTransform greenBar;

    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        float healthPercentage = currentHealth / maxHealth;
        greenBar.localScale = new Vector3(healthPercentage, 1f, 1f);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
