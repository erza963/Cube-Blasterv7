using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [Header("Coin Settings")]
    public GameObject coinPrefab;
    public float spawnRate = 2f;        // How often coins appear
    public int maxCoins = 10;           // Optional limit to prevent overload

    [Header("Ground Settings")]
    public Transform ground;            // Reference to your Ground object

    private float timer;

    void Start()
    {
        if (coinPrefab == null || ground == null)
        {
            Debug.LogError("CoinSpawner: Missing references! Assign coinPrefab and ground in Inspector.");
            return;
        }

        timer = spawnRate;
        SpawnCoin(); // spawn one immediately
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = spawnRate;
            SpawnCoin();
        }
    }

    void SpawnCoin()
    {
        if (coinPrefab == null || ground == null)
            return;

        // Optional: limit max coins in the scene
        if (GameObject.FindGameObjectsWithTag("Coin").Length >= maxCoins)
            return;

        // Calculate safe random position based on ground bounds
        float halfX = ground.localScale.x / 2f;
        float halfZ = ground.localScale.z / 2f;

        float spawnX = Random.Range(-halfX, halfX);
        float spawnZ = Random.Range(-halfZ, halfZ);

        Vector3 spawnPos = new Vector3(spawnX, 0.5f, spawnZ); // height of 0.5
        Instantiate(coinPrefab, spawnPos, Quaternion.identity);
    }
}
