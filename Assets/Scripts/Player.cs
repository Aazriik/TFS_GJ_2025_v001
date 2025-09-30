using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    public Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        float xMov = Input.GetAxisRaw("Horizontal");

        float yMov = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(xMov, yMov, 0);

        rb.MovePosition(transform.position + direction.normalized * speed * Time.deltaTime);
    }
}
