using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 5;
    public int currentHealth;

    [Header("UI Components")]
    public Slider healthSlider;           // Health bar
    public Image fillImage;               // Fill image color
    public GameObject heartPrefab;        // Heart prefab (assign in Inspector)
    public Transform heartContainer;      // UI container for hearts
    public List<GameObject> hearts = new List<GameObject>();

    private GameOverManager gameOverManager;

    void Start()
    {
        currentHealth = maxHealth;

        gameOverManager = FindFirstObjectByType<GameOverManager>();
        if (gameOverManager == null)
        {
            Debug.LogError("PlayerHealth: No GameOverManager found in scene!");
        }

        SpawnHearts();          // create hearts based on maxHealth
        UpdateHealthUI();       // sync visuals
    }

    void SpawnHearts()
    {
        // Clear existing hearts from UI and memory
        foreach (GameObject heart in hearts)
        {
            Destroy(heart);
        }
        hearts.Clear();

        // Create hearts equal to maxHealth
        for (int i = 0; i < maxHealth; i++)
        {
            GameObject newHeart = Instantiate(heartPrefab, heartContainer);
            hearts.Add(newHeart);
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UpdateHealthUI();
    }

    public void IncreaseMaxHealth(int amount)
    {
        maxHealth += amount;
        currentHealth = maxHealth;

        Debug.Log("New Max Health: " + maxHealth); // ✅ Debug message

        SpawnHearts();         // refresh hearts list and UI
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        if (healthSlider != null)
            healthSlider.value = (float)currentHealth / maxHealth;

        if (fillImage != null)
        {
            float t = (float)currentHealth / maxHealth;
            fillImage.color = Color.Lerp(Color.white, Color.green, t);
        }

        for (int i = 0; i < hearts.Count; i++)
        {
            hearts[i].SetActive(i < currentHealth);
        }
    }

    void Die()
    {
        Debug.Log("Player died!");
        if (gameOverManager != null)
        {
            gameOverManager.ShowGameOver();
        }
    }
}
