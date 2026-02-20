using UnityEngine;
using UnityEngine.SceneManagement; // This line is required!

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        // Replace "GameSceneName" with the exact name of your game scene
        SceneManager.LoadScene("GameScene");
    }
}