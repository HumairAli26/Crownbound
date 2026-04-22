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
        //anim.SetFloat("Speed", Mathf.Abs(move)!=0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Sword_Attack");
        }
        else if(Input.GetKeyDown(KeyCode.X))
        {
            anim.SetTrigger("Bow_Attack");
        }
    }
}