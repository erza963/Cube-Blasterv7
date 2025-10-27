using UnityEngine;
using TMPro;

public class CubeCollector : MonoBehaviour
{
    [Header("Leveling Settings")]
    public int cubesCollected = 0;        // Current progress toward next level
    public int cubesToLevelUp = 10;       // Required cubes per level
    public int totalCubesCollected = 0;   // Total collected across all levels

    [Header("UI Elements")]
    public GameObject levelUpPanel;
    public TextMeshProUGUI cubeCounterText;

    [Header("Upgrade References")]
    public GameObject player;  // Assign PlayerTurret or similar
    private bool hasChosenUpgrade = false;

    private void Start()
    {
        if (levelUpPanel != null)
            levelUpPanel.SetActive(false);

        // Load total cubes if persistence is desired
        totalCubesCollected = PlayerPrefs.GetInt("TotalCubes", 0);

        UpdateCubeText();
    }

    public void AddCube()
    {
        cubesCollected++;
        totalCubesCollected++;

        UpdateCubeText();

        if (cubesCollected >= cubesToLevelUp && !hasChosenUpgrade)
        {
            ShowLevelUpPanel();
        }

        // Save total count during play (optional)
        PlayerPrefs.SetInt("TotalCubes", totalCubesCollected);
    }

    private void UpdateCubeText()
    {
        if (cubeCounterText != null)
        {
            cubeCounterText.text =
                "Cubes: " + cubesCollected + " / " + cubesToLevelUp +
                "\nTotal: " + totalCubesCollected;
        }
    }

    // === Upgrade Methods ===
    public void UpgradeHealth()
    {
        if (hasChosenUpgrade) return;

        PlayerHealth health = player?.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.IncreaseMaxHealth(2);
            Debug.Log("Health upgraded by +2");
        }

        CompleteUpgrade();
    }

    public void UpgradeBulletSpeed()
    {
        if (hasChosenUpgrade) return;

        PlayerShooting shooting = player?.GetComponent<PlayerShooting>();
        if (shooting != null)
        {
            shooting.bulletSpeed *= 2;
            Debug.Log("Bullet speed doubled");
        }

        CompleteUpgrade();
    }

    public void UpgradeMovementSpeed()
    {
        if (hasChosenUpgrade) return;

        PlayerMovement movement = player?.GetComponent<PlayerMovement>();
        if (movement != null)
        {
            movement.moveSpeed += 2f;
            Debug.Log("Player movement speed increased by +2");
        }

        CompleteUpgrade();
    }

    // === Menu & Level Up Control ===
    public void QuitToMenu()
    {
        Time.timeScale = 1f;

        // Save total score for ScoreManager
        PlayerPrefs.SetInt("LastRunScore", totalCubesCollected);

        // Optional: also store overall progress
        PlayerPrefs.SetInt("TotalCubes", totalCubesCollected);
        PlayerPrefs.Save();

        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    private void ShowLevelUpPanel()
    {
        Time.timeScale = 0f;
        if (levelUpPanel != null)
            levelUpPanel.SetActive(true);
    }

    private void CompleteUpgrade()
    {
        hasChosenUpgrade = true;
        ClosePanel();
    }

    private void ClosePanel()
    {
        Time.timeScale = 1f;
        if (levelUpPanel != null)
            levelUpPanel.SetActive(false);

        // Keep leftover cubes after leveling
        cubesCollected -= cubesToLevelUp;
        if (cubesCollected < 0) cubesCollected = 0;

        UpdateCubeText();
        hasChosenUpgrade = false;
    }
}
