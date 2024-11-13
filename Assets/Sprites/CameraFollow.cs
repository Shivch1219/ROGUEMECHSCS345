using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform
    public float smoothSpeed = 0.125f; // Speed of camera movement smoothing
    public Vector3 offset; // Offset of the camera from the player

    void Start()
    {
        // Automatically find the player by tag if not manually assigned in the Inspector
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Calculate the target position of the camera based on the player's position and offset
            Vector3 targetPosition = player.position + offset;

            // Smoothly move the camera towards the target position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}

