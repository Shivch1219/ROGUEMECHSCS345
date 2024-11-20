using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player’s transform
    public Vector3 offset; // Offset to position the camera relative to the player
    public float smoothSpeed = 0.125f; // Speed of the camera movement

    void LateUpdate()
    {
        if (player != null)
        {
            // Desired position based on the player's position + offset
            Vector3 desiredPosition = player.position + offset;

            // Smoothly move the camera to the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            // Keep the camera facing forward (optional in 2D)
            transform.LookAt(player);
        }
    }
}
