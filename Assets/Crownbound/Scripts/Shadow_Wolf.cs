using UnityEngine;

public class ShadowWolf : MonoBehaviour
{
    public Transform player;
    public Transform wallCheck;
    public Transform groundCheck;

    public float moveSpeed = 3f;
    public float attackDistance = 3.5f;
    public float jumpForce = 8f;
    public float wallCheckDistance = 0.5f;
    public float groundCheckRadius = 0.2f;

    public LayerMask groundLayer;
    private bool isGrounded;
    private Rigidbody2D rb;
    private Animator anim;

    private EnemyAttack enemyAttack;
    private Vector3 originalScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        enemyAttack = GetComponent<EnemyAttack>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (player == null)
            return;
        // Check ground
        isGrounded =
            Physics2D.OverlapCircle(
                groundCheck.position,
                groundCheckRadius,
                groundLayer
            );
        // Horizontal distance only
        float distance = Mathf.Abs(player.position.x - transform.position.x);
        FlipTowardPlayer();
        // Chase player
        if (distance > attackDistance)
        {
            MoveTowardPlayer();
            anim.SetBool("Run", true);
            CheckWallAndJump();
        }
        else
        {
            StopMovement();
            anim.SetBool("Run", false);
            enemyAttack.Attack();
        }
    }

    void MoveTowardPlayer()
    {
        float direction = Mathf.Sign(player.position.x - transform.position.x);
        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);
    }

    void StopMovement()
    {
        rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
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

    void CheckWallAndJump()
    {
        Vector2 direction =
            player.position.x > transform.position.x
            ? Vector2.right
            : Vector2.left;

        RaycastHit2D wallHit =
            Physics2D.Raycast(
                wallCheck.position,
                direction,
                wallCheckDistance,
                groundLayer
            );
        // Jump if wall detected and grounded
        if (wallHit.collider != null && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
        Debug.DrawRay(
            wallCheck.position,
            direction * wallCheckDistance,
            Color.red
        );
    }

    void OnDrawGizmosSelected()
    {
        if (wallCheck != null)
        {
            Gizmos.color = Color.red;
            Vector2 direction =
                transform.localScale.x > 0
                ? Vector2.right
                : Vector2.left;
            Gizmos.DrawLine(
                wallCheck.position,
                (Vector2)wallCheck.position +
                direction * wallCheckDistance
            );
        }
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(
                groundCheck.position,
                groundCheckRadius
            );
        }
    }
}