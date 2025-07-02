using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles main menu actions such as starting the game or quitting the application.
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Quits the application.
    /// Note: Only works in a built executable.
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }

    /// <summary>
    /// Loads the first level or main game scene.
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene(1); // Consider using a constant or build index variable
    }
}