using UnityEngine;

public class Spirit : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float moveDistance = 5f;
    private Vector3 startPosition;
    private bool movingRight = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (movingRight)
        {
            transform.position +=
                Vector3.right *
                moveSpeed *
                Time.deltaTime;

            // Reached right limit
            if (transform.position.x >=
                startPosition.x + moveDistance)
            {
                movingRight = false;

                Flip();
            }
        }
        else
        {
            transform.position +=
                Vector3.left *
                moveSpeed *
                Time.deltaTime;

            // Reached left limit
            if (transform.position.x <=
                startPosition.x - moveDistance)
            {
                movingRight = true;

                Flip();
            }
        }
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;

        scale.x *= -1;

        transform.localScale = scale;
    }
}
