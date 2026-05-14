using UnityEngine;

public class Spirit : MonoBehaviour
{
    public Transform player;

    public float moveSpeed = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MoveTowardPlayer()
    {
        float direction = Mathf.Sign(player.position.x - transform.position.x);
        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);
    }

    void FlipTowardPlayer()
    {
        if (player.position.x > transform.position.x)
        {
            transform.localScale =
                new Vector3(
                    originalScale.x,
                    originalScale.y,
                    originalScale.z
                );
        }
        else
        {
            transform.localScale =
                new Vector3(
                    -originalScale.x,
                    originalScale.y,
                    originalScale.z
                );
        }
    }
}
