using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;

    private Animator am;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    public static bool facingRight = true; // shared direction for other scripts

    private float move;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        am = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        move = Input.GetAxis("Horizontal");

        // animation
        am.SetFloat("Speed", Mathf.Abs(move));

        // facing direction (IMPORTANT FIX)
        if (move > 0)
            facingRight = true;
        else if (move < 0)
            facingRight = false;

        // flip sprite
        sr.flipX = !facingRight;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);
    }
}