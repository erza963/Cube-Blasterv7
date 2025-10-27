using UnityEngine;

public class MenuNavigation : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainMenuPanel;
    public GameObject scoresPanel;

    // Opens the Scores screen
    public void OpenScores()
    {
        if (mainMenuPanel != null) mainMenuPanel.SetActive(false);
        if (scoresPanel != null) scoresPanel.SetActive(true);
    }

    // Returns to Main Menu
    public void BackToMenu()
    {
        if (scoresPanel != null) scoresPanel.SetActive(false);
        if (mainMenuPanel != null) mainMenuPanel.SetActive(true);
    }
}
