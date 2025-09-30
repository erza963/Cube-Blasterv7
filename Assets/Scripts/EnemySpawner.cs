using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
    public float spawnRate = 2f;

    private float minDistanceBetweenEnemies = 2f;
    private int maxSpawnAttempts = 10;

    void Start()
    {
        if (enemyPrefab == null || player == null)
        {
            Debug.LogError("EnemySpawner: Missing references! Assign enemyPrefab and player in the Inspector.");
            return;
        }

        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnRate);
    }

    void SpawnEnemy()
    {
        Vector3 spawnPos = GetValidSpawnPosition();
        if (spawnPos != Vector3.zero)
        {
            GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            EnemyMovement movement = enemy.GetComponent<EnemyMovement>();
            if (movement != null)
            {
                movement.target = player;
            }
            else
            {
                Debug.LogError("Spawned enemy is missing the EnemyMovement script!");
            }
        }
    }

    // ✅ Helper to find safe spawn position
    Vector3 GetValidSpawnPosition()
    {
        for (int attempt = 0; attempt < maxSpawnAttempts; attempt++)
        {
            float spawnX = Random.Range(-9f, 9f);
            float spawnZ = Random.Range(-9f, 9f);
            Vector3 spawnPos = new Vector3(spawnX, 0.5f, spawnZ);

            bool tooClose = false;
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                if (Vector3.Distance(spawnPos, obj.transform.position) < minDistanceBetweenEnemies)
                {
                    tooClose = true;
                    break;
                }
            }

            if (!tooClose)
                return spawnPos;
        }

        Debug.Log("EnemySpawner: Couldn't find safe spawn position.");
        return Vector3.zero;
    }
}
