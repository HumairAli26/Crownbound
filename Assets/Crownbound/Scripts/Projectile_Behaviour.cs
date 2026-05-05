using UnityEngine;

public class Projectile_Behaviour : MonoBehaviour
{
    private float damage = 20f;
    public float speed = 20f;

    private float direction;

    public void SetDirection(float dir)
    {
        direction = dir;
        // Flip visual
        transform.localScale = new Vector3(dir, 1, 1);
    }

    void Update()
    {
        transform.position += Vector3.right * direction * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if enemy was hit
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Access enemy script
            ShadowWolf wolf = collision.gameObject.GetComponent<ShadowWolf>();
            // Damage enemy
            if (wolf != null)
            {
                wolf.TakeDamage(damage);
            }
        }
        Destroy(gameObject);
    }
}