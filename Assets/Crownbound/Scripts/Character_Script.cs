using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float MAXhealth = 150f;
    private float currentHealth;
    public float speed = 5f;

    private Animator am;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    public static bool facingRight = true; // shared direction for other scripts

    private float move;

    void Start()
    {
        currentHealth = MAXhealth;
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
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log(gameObject.name + " Health: " + currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log(gameObject.name + " Died");
        Destroy(gameObject);
    }
}