using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAvoidance : MonoBehaviour
{
    public Transform player; 
    public float moveSpeed = 1.5f; 
    public float avoidDistance = 2f; 
    public float turnSpeed = 100f; 

    private Rigidbody2D rb;
    private bool avoidingObstacle = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (player == null) return;

        Vector2 directionToPlayer = (player.position - transform.position).normalized;

        // Cast a ray in the direction of movement to detect obstacles
        RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, avoidDistance);

        if (hit.collider != null && hit.collider.gameObject != player.gameObject)
        {
            // Object detected in path; start avoiding
            avoidingObstacle = true;
        }
        else
        {
            // No obstacle detected; stop avoiding and move toward player
            avoidingObstacle = false;
        }

        if (avoidingObstacle)
        {
            // Move in a perpendicular direction to avoid obstacle
            Vector2 avoidDirection = Vector2.Perpendicular(hit.normal).normalized;
            rb.velocity = avoidDirection * moveSpeed;
            rb.rotation = Mathf.Atan2(avoidDirection.y, avoidDirection.x) * Mathf.Rad2Deg;
        }
        else
        {
            // Move toward the player
            rb.velocity = directionToPlayer * moveSpeed;
            rb.rotation = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
        }
    }
}


