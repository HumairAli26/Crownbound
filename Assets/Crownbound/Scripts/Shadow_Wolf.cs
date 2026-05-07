using UnityEngine;

public class ShadowWolf : MonoBehaviour
{
    public Transform player;

    public float moveSpeed = 3f;
    public float attackDistance = 3.5f;

    private Rigidbody2D rb;
    private Animator anim;

    private EnemyAttack enemyAttack;

    private Vector3 originalScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        enemyAttack = GetComponent<EnemyAttack>();

        player =
            GameObject.FindGameObjectWithTag("Player").transform;

        originalScale = transform.localScale;
    }

    void Update()
    {
        if (player == null)
            return;

        // Horizontal distance only
        float distance =
            Mathf.Abs(player.position.x - transform.position.x);

        FlipTowardPlayer();

        // Chase player
        if (distance > attackDistance)
        {
            MoveTowardPlayer();

            anim.SetBool("Run", true);
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
        float direction =
            Mathf.Sign(player.position.x - transform.position.x);

        rb.linearVelocity =
            new Vector2(direction * moveSpeed, rb.linearVelocity.y);
    }

    void StopMovement()
    {
        rb.linearVelocity =
            new Vector2(0, rb.linearVelocity.y);
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