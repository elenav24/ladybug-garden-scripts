using UnityEngine;
using UnityEngine.SceneManagement; // This line is required!

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        // Replace "GameSceneName" with the exact name of your game scene
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        #if UNITY_WEBGL && !UNITY_EDITOR
            Application.OpenURL("https://itch.io"); // Redirect for Web
        #else
            Application.Quit(); // Standard Quit
        #endif
    }
}