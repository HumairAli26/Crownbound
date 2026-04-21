using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Movement example (optional)
        float move = Input.GetAxis("Horizontal");
        anim.SetBool("isWalking", move != 0);

        // Attack when space pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Attack");
        }
    }
}