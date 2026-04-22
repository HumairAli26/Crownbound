using UnityEngine;

public class Character_Attacks : MonoBehaviour
{
    Animator anim;
    public Transform launchOffSet; 
    public Projectile_Behaviour projectilePrefab;

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
            Invoke("Arrow_Projectile",0.33f);
        }
    }

    private void Arrow_Projectile() 
    {
        Instantiate(projectilePrefab,launchOffSet.position,transform.rotation);
    }
}