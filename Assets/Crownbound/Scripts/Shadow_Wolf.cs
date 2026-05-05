using UnityEngine;

public class ShadowWolf : MonoBehaviour
{
    public Transform player;

    public float health =50f;
    public float moveSpeed = 3f;
    public float attackDistance = 3.5f;

    private Rigidbody2D rb;
    private Animator anim;

    private bool isAttacking = false;
    private float attackCooldown = 1f;
    private float attackTimer;

    Vector3 originalScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("Player").transform;

        originalScale = transform.localScale;
    }

    void Update()
    {
        if (player == null)
            return;

        // Attack cooldown timer
        attackTimer += Time.deltaTime;

        // Horizontal distance only
        float distance = Mathf.Abs(player.position.x - transform.position.x);

        // Flip toward player
        if (player.position.x > transform.position.x)
            transform.localScale =
                new Vector3(originalScale.x, originalScale.y, originalScale.z);
        else
            transform.localScale =
                new Vector3(-originalScale.x, originalScale.y, originalScale.z);

        // If player is far → chase
        if (distance > attackDistance)
        {
            isAttacking = false;

            float direction =
                Mathf.Sign(player.position.x - transform.position.x);

            rb.linearVelocity =
                new Vector2(direction * moveSpeed, rb.linearVelocity.y);

            anim.SetBool("Run", true);
        }
        else
        {
            // Stop moving near player
            rb.linearVelocity =
                new Vector2(0, rb.linearVelocity.y);

            anim.SetBool("Run", false);

            // Attack with cooldown
            if (attackTimer >= attackCooldown)
            {
                attackTimer = 0;

                anim.SetTrigger("Attack");
            }
        }
    }
    void takeDamage(int damage)
    {
        
    }
}