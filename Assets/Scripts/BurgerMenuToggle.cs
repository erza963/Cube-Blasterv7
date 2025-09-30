using UnityEngine;

public class BurgerMenuToggle : MonoBehaviour
{
    public GameObject burgerMenuPanel;

    private bool isOpen = false;

    void Start()
    {
        if (burgerMenuPanel != null)
            burgerMenuPanel.SetActive(false);
    }

    public void ToggleMenu()
    {
        isOpen = !isOpen;
        burgerMenuPanel.SetActive(isOpen);
    }
}
