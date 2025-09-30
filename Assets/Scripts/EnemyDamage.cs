using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int health = 1;
    public int damageAmount = 1;

    private CubeCollector cubeCollector;

    void Start()
    {
        // Use newer, recommended API to avoid deprecation warnings
        cubeCollector = FindFirstObjectByType<CubeCollector>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth healthScript = other.GetComponent<PlayerHealth>();
            if (healthScript != null)
            {
                healthScript.TakeDamage(damageAmount);
            }
        }
        else if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject); // Destroy bullet
            health--;

            if (health <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        if (cubeCollector != null)
        {
            cubeCollector.AddCube();
        }

        Destroy(gameObject); // Destroy enemy
    }
}
