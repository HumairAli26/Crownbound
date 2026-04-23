using UnityEngine;

public class Character_Attacks : MonoBehaviour
{
    Animator anim;

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
}