using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform attackPoint;

    public float attackRange = 1.5f;
    public float damage = 20f;

    public LayerMask playerLayer;

    public float attackCooldown = 1f;

    private float attackTimer;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        attackTimer += Time.deltaTime;
    }

    public void Attack()
    {
        if (attackTimer < attackCooldown)
            return;

        attackTimer = 0;

        anim.SetTrigger("Attack");

        Collider2D[] hitPlayer =
            Physics2D.OverlapCircleAll(
                attackPoint.position,
                attackRange,
                playerLayer
            );

        foreach (Collider2D player in hitPlayer)
        {
            Character_Script health =
                player.GetComponent<Character_Script>();

            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(
            attackPoint.position,
            attackRange
        );
    }
}