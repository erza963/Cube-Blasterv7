using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target; // Player reference
    public float baseSpeed = 2f;
    private float speed;

    public float avoidDistance = 1.5f;
    public float avoidStrength = 1f;

    void Start()
    {
        // Set initial speed scaled by level
        ScaleSpeedByLevel(LevelManager.CurrentLevel);
    }

    public void ScaleSpeedByLevel(int level)
    {
        // Enemies move faster with each level
        speed = baseSpeed + (level - 1) * 0.5f; 
    }

    void Update()
    {
        if (target == null) return;

        // Move toward player
        Vector3 moveDir = (target.position - transform.position).normalized;

        // Avoid overlapping with nearby enemies
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

            Destroy(gameObject); // Optional: remove after hitting player
        }
    }
}
