using UnityEngine;

public class Jummping : MonoBehaviour
{
    public float speed = 5f;
    private float move;
    public Rigidbody2D playerRb;
    public Animator anim;
    public float JumpForce=5;
    public float GravityModifier;
    public bool isonground=true;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Physics.gravity*=GravityModifier;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && isonground)
        {
            playerRb.AddForce(Vector3.up*JumpForce,ForceMode2D.Impulse);
            anim.SetTrigger("Jump");
            move = Input.GetAxis("Horizontal");
            isonground=false;
        }
    }

    private void FixedUpdate()
    {
        playerRb.linearVelocity = new Vector2(move * speed, playerRb.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isonground=true;
    }
}