using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject gameplayUI;
    public GameObject player;
    public GameObject ground;
    public GameObject spawner;

    public void OnStartClicked()
    {
        mainMenuPanel.SetActive(false);
        gameplayUI.SetActive(true);
        player.SetActive(true);
        ground.SetActive(true);
        spawner.SetActive(true);
    }

    public void OnMenuClicked()
    {
        Debug.Log("Menu button clicked");
    }
}
