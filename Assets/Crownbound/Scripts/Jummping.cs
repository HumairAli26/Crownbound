using UnityEngine;

public class Jummping : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public Animator anim;
    public float JumpForce=10;
    public float GravityModifier;
    public bool isonground=true;
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Physics.gravity*=GravityModifier;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && isonground)
        {
            playerRb.AddForce(Vector3.up*JumpForce,ForceMode2D.Impulse);
            isonground=false;
        }
    }
    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision collision)
    {
        isonground=true;
    }
}