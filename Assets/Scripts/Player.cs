using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    public Rigidbody2D rb;

    void FixedUpdate()
    {
        float xMov = Input.GetAxisRaw("Horizontal");

        float yMov = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(xMov, yMov);

        rb.MovePosition(
            new Vector2(transform.position.x, transform.position.y)
            + new Vector2(direction.normalized.x, direction.normalized.y)
            * speed * Time.deltaTime
        );
    }
}
