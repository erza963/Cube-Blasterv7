using UnityEngine;
using UnityEngine.UI;

public class HeartDisplay : MonoBehaviour
{
    public Image[] hearts;               // Assign heart UI Images here
    public PlayerHealth playerHealth;    // Drag PlayerHealth object here

    void Start()
    {
        if (playerHealth == null)
        {
            playerHealth = UnityEngine.Object.FindFirstObjectByType<PlayerHealth>();
            if (playerHealth == null)
            {
                Debug.LogError("HeartDisplay: PlayerHealth is not assigned!");
            }
        }

        if (hearts == null || hearts.Length == 0)
        {
            Debug.LogError("HeartDisplay: Hearts array is not assigned or empty!");
        }
    }

    void Update()
    {
        if (playerHealth == null || hearts == null || hearts.Length == 0)
            return;

        int safeLength = Mathf.Min(hearts.Length, playerHealth.maxHealth);

        for (int i = 0; i < safeLength; i++)
        {
            if (hearts[i] == null) continue; // prevent null element crash

            hearts[i].enabled = i < playerHealth.currentHealth;
        }
    }
}
