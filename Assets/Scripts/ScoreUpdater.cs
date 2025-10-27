using UnityEngine;

public class ScoreUpdater : MonoBehaviour
{
    public ScoreManager scoreManager;

    private void Start()
    {
        if (PlayerPrefs.HasKey("LastRunScore"))
        {
            int lastRun = PlayerPrefs.GetInt("LastRunScore");
            scoreManager.AddNewScore(lastRun);

            // Clear after using it
            PlayerPrefs.DeleteKey("LastRunScore");
        }
    }
}
