using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    private Vector2 direction;

    public void SetDirection(Vector2 targetDirection)
    {
        direction = targetDirection.normalized;
    }

    void Update()
    {
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Health>()?.TakeDamage(10f);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
