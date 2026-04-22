using UnityEngine;

public class Projectile_Behaviour : MonoBehaviour
{
    public float Speed = 8f;
    private void Update()
    {
        transform.position += transform.right * Time.deltaTime * Speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}