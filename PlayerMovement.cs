using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private float moveInput;
    private bool isGrounded;

    private Animator animator;

    private float spaceHoldTime = 0f;
    private float glideThreshold = 0.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // left and right movement
        moveInput = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            animator.SetBool("isJumping", true);
            spaceHoldTime = 0f; // reset hold time when jump starts
        }

        if (Input.GetKey(KeyCode.Space) && !isGrounded) // While holding and in the air
        {
            spaceHoldTime += Time.deltaTime;
            if (spaceHoldTime >= glideThreshold && rb.linearVelocity.y < 0)
            {
                rb.gravityScale = 0.5f;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.gravityScale = 2f;
            spaceHoldTime = 0f;
        }

        if (!isGrounded && rb.linearVelocity.y < -1f)
        {
            animator.SetBool("isJumping", true);
        }
    }


    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
            spaceHoldTime = 0f; // reset hold time when landing
            rb.gravityScale = 2f;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Mathf.Abs(collision.contacts[0].normal.y) < 0.1f) // If the collision normal is mostly horizontal, we consider it a wall
        {
            isGrounded = false;
            animator.SetBool("isJumping", true);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, -5f);
        }

        if (collision.gameObject.CompareTag("Ground") && rb.linearVelocity.y <= 0.1f && collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
            spaceHoldTime = 0f; // reset hold time when landing
            rb.gravityScale = 2f;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}