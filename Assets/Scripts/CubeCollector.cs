using UnityEngine;
using TMPro;

public class CubeCollector : MonoBehaviour
{
    [Header("Leveling Settings")]
    public int cubesCollected = 0;
    public int cubesToLevelUp = 10;

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

        UpdateCubeText();
    }

    public void AddCube()
    {
        cubesCollected++;
        UpdateCubeText();

        if (cubesCollected >= cubesToLevelUp && !hasChosenUpgrade)
        {
            ShowLevelUpPanel();
        }
    }

    private void UpdateCubeText()
    {
        if (cubeCounterText != null)
        {
            cubeCounterText.text = "Cubes: " + cubesCollected;
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
            movement.moveSpeed += 2f; // Increase player speed by 2 units
            Debug.Log("Player movement speed increased by +2");
        }

        CompleteUpgrade();
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1f;
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
        
        cubesCollected = 0;
        UpdateCubeText();
        hasChosenUpgrade = false;
    }
}
