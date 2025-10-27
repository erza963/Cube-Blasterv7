using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI score1Text;
    public TextMeshProUGUI score2Text;
    public TextMeshProUGUI score3Text;

    private int[] scores = new int[3];

    private void Start()
    {
        LoadScores();
        DisplayScores();
    }

    private void LoadScores()
    {
        scores[0] = PlayerPrefs.GetInt("Score1", 0);
        scores[1] = PlayerPrefs.GetInt("Score2", 0);
        scores[2] = PlayerPrefs.GetInt("Score3", 0);
    }

    private void DisplayScores()
    {
        if (score1Text != null) score1Text.text = "Score: " + scores[0];
        if (score2Text != null) score2Text.text = "Score: " + scores[1];
        if (score3Text != null) score3Text.text = "Score: " + scores[2];
    }

    // Optional reset function
    public void ResetScores()
    {
        PlayerPrefs.DeleteKey("Score1");
        PlayerPrefs.DeleteKey("Score2");
        PlayerPrefs.DeleteKey("Score3");
        PlayerPrefs.Save();
        LoadScores();
        DisplayScores();
        Debug.Log("Scores reset!");
    }
}
