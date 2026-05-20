using UnityEngine;

public class Spirit_Shot : MonoBehaviour
{
    public float damage = 20f;
    private float lifetime = 20f;
    public float speed = 10f;

    private Vector2 moveDirection;

    void Start() 
    {
        Destroy(gameObject,lifetime);    
    }

    // Called when projectile is spawned
    public void SetTarget(Vector2 targetPosition)
    {
        // Calculate direction toward target
        moveDirection = (targetPosition - (Vector2)transform.position).normalized;
        // Flip sprite
        if (moveDirection.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);
    }

    void Update()
    {
        transform.position += (Vector3)(moveDirection * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Damage player
        if (collision.gameObject.CompareTag("Player"))
        {
            Character_Script health = collision.gameObject.GetComponent<Character_Script>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
        Destroy(gameObject);
        
    }

    private void OnBecameInvisible() 
    {
        Destroy(gameObject);    
    }
}