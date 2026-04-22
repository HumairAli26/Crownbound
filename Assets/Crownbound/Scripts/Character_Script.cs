using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;

    private Animator am;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private float move;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        am = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>(); // ✅ added
    }

    void Update()
    {
        move = Input.GetAxis("Horizontal");
        am.SetFloat("Speed", Mathf.Abs(move));
        if (move > 0)
        {
            sr.flipX = false; // Face right
        }
        else if (move < 0)
        {
            sr.flipX = true; // Face left
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);
    }
}
