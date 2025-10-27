using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI score1Text;
    public TextMeshProUGUI score2Text;
    public TextMeshProUGUI score3Text;

    private int[] lastScores = new int[3];

    private void Start()
    {
        LoadScores();
        DisplayScores();
    }

    public void AddNewScore(int newScore)
    {
        // Shift older scores down
        lastScores[2] = lastScores[1];
        lastScores[1] = lastScores[0];
        lastScores[0] = newScore;

        SaveScores();
        DisplayScores();
    }

    private void SaveScores()
    {
        PlayerPrefs.SetInt("Score1", lastScores[0]);
        PlayerPrefs.SetInt("Score2", lastScores[1]);
        PlayerPrefs.SetInt("Score3", lastScores[2]);
        PlayerPrefs.Save();
    }

    private void LoadScores()
    {
        lastScores[0] = PlayerPrefs.GetInt("Score1", 0);
        lastScores[1] = PlayerPrefs.GetInt("Score2", 0);
        lastScores[2] = PlayerPrefs.GetInt("Score3", 0);
    }

    private void DisplayScores()
    {
        if (score1Text != null) score1Text.text = "Score: " + lastScores[0];
        if (score2Text != null) score2Text.text = "Score: " + lastScores[1];
        if (score3Text != null) score3Text.text = "Score: " + lastScores[2];
    }
}
