using UnityEngine;

public class TurretController : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform
    public float rotationSpeed = 5f; // Speed of turret rotation

    void Start()
    {
        // Find the player in the scene (assuming player has a tag "Player")
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        if (player != null)
        {
            // Calculate the direction to the player
            Vector2 direction = player.position - transform.position;

            // Calculate the angle between the turret's forward direction and the player
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Rotate smoothly towards the player
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
