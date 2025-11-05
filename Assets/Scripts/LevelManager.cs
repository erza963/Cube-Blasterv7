using UnityEngine;
using System;

public class LevelManager : MonoBehaviour
{
    public static int CurrentLevel = 1;

    // 🔔 Event that notifies other scripts (like EnemySpawner) when level changes
    public static event Action<int> OnLevelChanged;

    public static void IncreaseLevel()
    {
        CurrentLevel++;
        Debug.Log($"Level Up! Enemies stronger. Level: {CurrentLevel}");
        OnLevelChanged?.Invoke(CurrentLevel); // Notify subscribers
    }

    public static void ResetLevel()
    {
        CurrentLevel = 1;
        OnLevelChanged?.Invoke(CurrentLevel);
    }
}
