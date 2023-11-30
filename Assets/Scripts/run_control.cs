using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Adjust the speed as needed
    public float jumpForce = 10f; // Adjust the initial jump force
    public float doubleJumpForce = 7f; // Adjust the double jump force
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool hasDoubleJumped;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        // Reset double jump flag when grounded
        if (isGrounded)
        {
            hasDoubleJumped = false;
        }

        // Move the player
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // Jumping
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        else if (!isGrounded && !hasDoubleJumped && Input.GetButtonDown("Jump"))
        {
            // Perform double jump
            rb.velocity = new Vector2(rb.velocity.x, doubleJumpForce);
            hasDoubleJumped = true;
        }
    }
}
