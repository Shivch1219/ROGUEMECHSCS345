using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed for moving towards player
    public float stoppingDistance = 1.5f; // Minimum distance from player
    public float separationDistance = 1.5f; // Minimum distance from other enemies
    public float separationForce = 5f; // Strength of the separation force
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            Vector2 moveDirection = Vector2.zero;

            // Constantly apply separation force to maintain distance from other enemies
            Collider2D[] nearbyEnemies = Physics2D.OverlapCircleAll(transform.position, separationDistance);
            foreach (Collider2D enemy in nearbyEnemies)
            {
                if (enemy != null && enemy.gameObject != gameObject && enemy.CompareTag("Enemy"))
                {
                    Vector2 directionAway = (transform.position - enemy.transform.position).normalized;
                    float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
                    
                    // Apply a strong repulsive force inversely proportional to distance (closer enemies repel more)
                    if (distanceToEnemy < separationDistance)
                    {
                        moveDirection += directionAway * separationForce * (separationDistance - distanceToEnemy);
                    }
                }
            }

            // Move towards the player if beyond the stopping distance
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            if (distanceToPlayer > stoppingDistance)
            {
                Vector2 directionToPlayer = (player.position - transform.position).normalized;
                moveDirection += directionToPlayer * moveSpeed;
            }

            // Apply the calculated movement direction
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + moveDirection, moveSpeed * Time.deltaTime);
        }
    }
}




