using UnityEngine;

public class Character_Attacks : MonoBehaviour
{
    Animator anim;
    public Transform Sword_hitbox;

    public float attackRange = 1f;
    public float swordDamage = 20f;

    public LayerMask enemyLayers;

    public Transform launchOffSet;
    public Projectile_Behaviour projectilePrefab;

    private Vector3 originalOffset;

    void Start()
    {
        anim = GetComponent<Animator>();

        // store original RIGHT position of launch point
        originalOffset = launchOffSet.localPosition;
    }

    void Update()
    {
        // Sword attack
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Sword_Attack");
            Attack();

        }

        // Bow attack
        if (Input.GetKeyDown(KeyCode.X))
        {
            anim.SetTrigger("Bow_Attack");
            Invoke(nameof(Arrow_Projectile), 0.35f);
        }

        UpdateLaunchOffset();
    }

    void UpdateLaunchOffset()
    {
        if (PlayerMove.facingRight)
        {
            launchOffSet.localPosition = originalOffset;
        }
        else
        {
            launchOffSet.localPosition = new Vector3(
                -originalOffset.x,
                originalOffset.y,
                originalOffset.z
            );
        }
    }

    void Arrow_Projectile()
    {
        Projectile_Behaviour arrow =
            Instantiate(projectilePrefab, launchOffSet.position, Quaternion.identity);

        float dir = PlayerMove.facingRight ? 1f : -1f;
        arrow.SetDirection(dir);
    }

    void Attack()
    {
        Collider2D[] hitEnemies =
            Physics2D.OverlapCircleAll(
                Sword_hitbox.position,
                attackRange,
                enemyLayers
            );

        foreach (Collider2D enemy in hitEnemies)
        {
            EnemyHealth enemyHealth =
                enemy.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(swordDamage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (Sword_hitbox == null)
            return;

        Gizmos.DrawWireSphere(
            Sword_hitbox.position,
            attackRange
        );
    }
}