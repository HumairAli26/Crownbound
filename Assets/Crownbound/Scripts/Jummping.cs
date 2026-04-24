using UnityEngine;

public class Jumping : MonoBehaviour
{
    public float jumpForce = 10f;
    public bool isOnGround = true;

    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isOnGround)
        {
            anim.SetTrigger("Jump");
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isOnGround = true;
    }
}