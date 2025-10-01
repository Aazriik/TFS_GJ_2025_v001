using UnityEngine;

public class Player : MonoBehaviour
{
    // Variables
    bool isWalking = false;
    public float moveSpeed;
    public Animator anim;
    public Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 lastMoveDirection;

    public Flashlight fLight;

    public SpriteRenderer sr;

    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        anim.SetFloat("MoveX", 0);
        anim.SetFloat("MoveY", -1);

        fLight = GetComponent<Flashlight>();
    }

    // Update is called once per frame
    void Update()
    {
        // Process Inputs
        ProcessInputs();

        // Animate
        Animate();

        if (sr.sprite == sprites[0])
        {
            fLight.flashlight.gameObject.transform.rotation = Quaternion.Euler(0, 0, -90f);
        }

        else if (sr.sprite == sprites[1])
        {
            fLight.flashlight.gameObject.transform.rotation = Quaternion.Euler(0, 0, -270f);
        }

        else if (sr.sprite == sprites[2])
        {
            fLight.flashlight.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0f);
        }

        else if (sr.sprite == sprites[3])
        {
            fLight.flashlight.gameObject.transform.rotation = Quaternion.Euler(0, 0, 180f);
        }
    }

    // Called once per Physics frame - used for physics (Movement)
    void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if (isWalking)
        {
            Vector3 vector3 = Vector3.left * movement.x + Vector3.down * movement.y;
        }
    }

    /*void FixedUpdate()
    {
        float xMov = Input.GetAxisRaw("Horizontal");

        float yMov = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(xMov, yMov);

        rb.MovePosition(
            new Vector2(transform.position.x, transform.position.y)
            + new Vector2(direction.normalized.x, direction.normalized.y)
            * speed * Time.deltaTime
        );
    }*/

    void ProcessInputs()
    {
        // Store last move direction when we stop moving
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if ((moveX == 0 && moveY == 0) && (movement.x != 0 || movement.y != 0))
        {
            isWalking = false;
            lastMoveDirection = movement;

            Vector3 vector3 = Vector3.left * lastMoveDirection.x + Vector3.down * lastMoveDirection.y;
        }

        else if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 ||
            Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            isWalking = true;
        }

        // Moving
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize(); // Makes diagonal movement the same speed as other movements
    }

    void Animate()
    {
        // Set our animator parameters
        anim.SetFloat("MoveX", movement.x);
        anim.SetFloat("MoveY", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);
        anim.SetFloat("LastMoveX", lastMoveDirection.x);
        anim.SetFloat("LastMoveY", lastMoveDirection.y);
    }
}
