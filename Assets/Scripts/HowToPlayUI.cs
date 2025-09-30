using UnityEngine;

public class HowToPlayUI : MonoBehaviour
{
    [SerializeField] private GameObject howToPlayPanel;
    [SerializeField] private GameObject mainMenuPanel;

    void Start()
    {
        if (howToPlayPanel != null)
            howToPlayPanel.SetActive(false); // hidden at launch
    }

    public void OpenHowToPlay()
    {
        if (howToPlayPanel != null) howToPlayPanel.SetActive(true);
        if (mainMenuPanel != null) mainMenuPanel.SetActive(false);
    }

    public void CloseHowToPlay()
    {
        if (howToPlayPanel != null) howToPlayPanel.SetActive(false);
        if (mainMenuPanel != null) mainMenuPanel.SetActive(true);
    }
}
