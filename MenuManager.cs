using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
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
