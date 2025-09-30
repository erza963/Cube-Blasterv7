using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target; // Player reference
    public float speed = 2f;

    public float avoidDistance = 1.5f;    // Distance to maintain from other enemies
    public float avoidStrength = 1f;      // How strongly to push away

    void Update()
    {
        if (target == null) return;

        // Start with direction toward the player
        Vector3 moveDir = (target.position - transform.position).normalized;

        // Add repelling force from nearby enemies
        foreach (GameObject other in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if (other != this.gameObject)
            {
                float dist = Vector3.Distance(transform.position, other.transform.position);
                if (dist < avoidDistance)
                {
                    Vector3 away = (transform.position - other.transform.position).normalized;
                    moveDir += away * (avoidStrength / dist);
                }
            }
        }

        moveDir = moveDir.normalized;
        transform.position += moveDir * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth health = other.gameObject.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(1);
            }

            Destroy(gameObject); // Optional: remove enemy after damaging
        }
    }
}
