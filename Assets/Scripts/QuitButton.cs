using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour
{
    public void GoToMainMenu()
    {
        // Reloads the current scene (resets everything)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
