using UnityEngine;

public class Spirit : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float moveDistance = 5f;

    [Header("Attack")]
    public Spirit_Shot projectilePrefab;
    public Transform firePoint;
    public Transform player;
    public float attackCooldown = 2f;
    private float attackTimer;
    private Vector3 startPosition;
    private bool movingRight = true;

    void Start()
    {
        startPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Move();
        Attack();
    }

    void Move()
    {
        if (movingRight)
        {
            transform.position +=
                Vector3.right *
                moveSpeed *
                Time.deltaTime;

            // Reached right limit
            if (transform.position.x >=
                startPosition.x + moveDistance)
            {
                movingRight = false;

                Flip();
            }
        }
        else
        {
            transform.position +=
                Vector3.left *
                moveSpeed *
                Time.deltaTime;

            // Reached left limit
            if (transform.position.x <=
                startPosition.x - moveDistance)
            {
                movingRight = true;

                Flip();
            }
        }
    }

    void Attack()
    {
        if (player == null)
            return;

        attackTimer += Time.deltaTime;

        // Shoot after cooldown
        if (attackTimer >= attackCooldown)
        {
            attackTimer = 0;

            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        Spirit_Shot shot =
            Instantiate(
                projectilePrefab,
                firePoint.position,
                Quaternion.identity
            );

        shot.SetTarget(player.position);
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;

        scale.x *= -1;

        transform.localScale = scale;
    }
}