using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;

    [Header("Spawn Settings")]
    public float baseSpawnRate = 2f;  // initial delay between spawns
    public float minSpawnRate = 0.5f; // minimum cap
    private float currentSpawnRate;
    private float spawnTimer;

    private float minDistanceBetweenEnemies = 2f;
    private int maxSpawnAttempts = 10;

    void Start()
    {
        if (enemyPrefab == null || player == null)
        {
            Debug.LogError("EnemySpawner: Missing references! Assign enemyPrefab and player in the Inspector.");
            enabled = false;
            return;
        }

        currentSpawnRate = baseSpawnRate;
        spawnTimer = currentSpawnRate;

        // 🔗 Listen for level-up event
        LevelManager.OnLevelChanged += HandleLevelUp;
    }

    void OnDestroy()
    {
        // Prevent event leaks when reloading
        LevelManager.OnLevelChanged -= HandleLevelUp;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            SpawnEnemy();
            spawnTimer = currentSpawnRate;
        }
    }

    private void HandleLevelUp(int newLevel)
    {
        // Each new level slightly reduces spawn delay
        currentSpawnRate = Mathf.Max(minSpawnRate, baseSpawnRate - (newLevel - 1) * 0.2f);
        Debug.Log($"⚡ Enemy spawn rate increased! New rate: {currentSpawnRate:F2}s");
    }

    void SpawnEnemy()
    {
        Vector3 spawnPos = GetValidSpawnPosition();
        if (spawnPos == Vector3.zero) return;

        GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

        // Assign player target
        EnemyMovement movement = enemy.GetComponent<EnemyMovement>();
        if (movement != null)
        {
            movement.target = player;
            movement.ScaleSpeedByLevel(LevelManager.CurrentLevel);
        }

        // Scale enemy health
        EnemyHealth health = enemy.GetComponent<EnemyHealth>();
        if (health != null)
        {
            health.InitializeHealth(LevelManager.CurrentLevel);
        }
    }

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

        return Vector3.zero;
    }
}
