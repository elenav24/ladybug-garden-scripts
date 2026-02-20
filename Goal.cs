using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public GameObject winMenu;

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
    }
}
