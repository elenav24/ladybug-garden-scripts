using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public GameObject winMenu; // Drag your WinMenu Panel here in the Inspector

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player touched the pink flower
        if (collision.gameObject.CompareTag("Player"))
        {
            WinGame();
        }
    }

    void WinGame()
    {
        winMenu.SetActive(true); // Show the win screen
        Time.timeScale = 0f;    // Freeze the game physics
        
        // Optional: Play a sound or victory animation here
        Debug.Log("Level Complete!");
    }

    // This function can be linked to your "Next Level" button
    public void LoadNextLevel()
    {
        Time.timeScale = 1f; // IMPORTANT: Unfreeze time before switching levels
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            SceneManager.LoadScene("MainMenu"); // Go back to start if no levels left
        }
    }
}