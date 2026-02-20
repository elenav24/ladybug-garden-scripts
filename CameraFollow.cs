using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float minX = 0f; // the start of the level
    public float maxX = 100f; // the end of the level (the goal)
    private float targetY = -.2f;

    void LateUpdate()
    {
        // Calculate the new position
        float targetX = Mathf.Clamp(player.position.x, minX, maxX);

        // Apply the position while keeping the camera's Z at -10
        transform.position = new Vector3(targetX, targetY, -1.5f);
    }
}