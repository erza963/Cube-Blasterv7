using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("Coin Settings")]
    public int coinValue = 1;
    private CoinManager coinManager;

    private void Start()
    {
        // Use Unity 6+ optimized method
        coinManager = Object.FindFirstObjectByType<CoinManager>();

        if (coinManager == null)
        {
            Debug.LogWarning("CoinManager not found in the scene.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Ensure the Player tag is set properly on the player object
        if (other.CompareTag("Player"))
        {
            if (coinManager != null)
            {
                coinManager.AddCoin(coinValue);
                Debug.Log($"Coin collected! +{coinValue}");
            }
            else
            {
                Debug.LogWarning("CoinManager reference missing; cannot add coin value.");
            }

            // Optional: Add a small pickup delay effect if needed
            Destroy(gameObject);
        }
    }
}
