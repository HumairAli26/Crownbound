using UnityEngine;

public class ShadowWolf : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;
    public float attackDistance = 1.5f;
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        // Automatically find player
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null)
            return;

        float distance = Vector2.Distance(transform.position, player.position);

        // Move toward player
        if (distance > attackDistance)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.linearVelocity = new Vector2(direction.x * moveSpeed, rb.linearVelocity.y);
            anim.SetBool("Run", true);

            // Flip enemy
            if (direction.x > 0)
                transform.localScale = new Vector3(1, 1, 1);
            else if (direction.x < 0)
                transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            // Stop and attack
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            anim.SetBool("Run", false);
            anim.SetTrigger("Attack");
        }
    }
}