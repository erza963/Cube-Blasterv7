using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public int totalCoins = 0;
    public TextMeshProUGUI coinText;

    private void Start()
    {
        UpdateCoinUI();
    }

    public void AddCoin(int amount)
    {
        totalCoins += amount;
        UpdateCoinUI();
    }

    private void UpdateCoinUI()
    {
        if (coinText != null)
            coinText.text = "Coins: " + totalCoins;
    }
}
