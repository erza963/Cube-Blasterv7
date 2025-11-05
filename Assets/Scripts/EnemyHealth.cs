using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int baseHealth = 1;
    private int currentHealth;

    public void InitializeHealth(int level)
    {
        currentHealth = baseHealth + (level - 1);  // 1HP → 2HP → 3HP...
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
