using UnityEngine;
using System.Collections;

public class FlowerBoost : MonoBehaviour
{
    private PlayerMovement movement;
    public float boostMultiplier = 2f;
    public float boostDuration = 10f;
    
    private float timeRemaining = 0f;
    private bool isBoosted = false;
    private float originalSpeed;

    void Start()
    {
        movement = GetComponent<PlayerMovement>();
        originalSpeed = movement.moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Flower"))
        {
            // 1. Add time to the timer
            timeRemaining += boostDuration;

            // 2. If not already boosted, start the logic
            if (!isBoosted)
            {
                StartCoroutine(BoostTimer());
            }
            
            Destroy(collision.gameObject); // destroy the flower on contact
        }
    }

    IEnumerator BoostTimer()
    {
        isBoosted = true;
        movement.moveSpeed = originalSpeed * boostMultiplier;
        GetComponent<SpriteRenderer>().color = new Color(1f, 0.8f, 0.8f); // Slight pink tint

        // Keep running as long as there is time left
        while (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // 3. Reset when time is finally up
        timeRemaining = 0;
        movement.moveSpeed = originalSpeed;
        isBoosted = false;
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}