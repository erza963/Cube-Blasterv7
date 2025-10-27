using UnityEngine;

public class StartButton : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;  // Menu to hide
    [SerializeField] private GameObject gameplayUI;     // Gameplay UI to show
    [SerializeField] private GameObject player;         // Player object
    [SerializeField] private GameObject spawner;        // Enemy or object spawner

    public void StartGame()
    {
        // Unpause time
        Time.timeScale = 1f;

        // Show/hide panels
        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(false);
        if (gameplayUI != null)
            gameplayUI.SetActive(true);

        // Enable player and game systems
        if (player != null)
            player.SetActive(true);
        if (spawner != null)
            spawner.SetActive(true);
    }
}
