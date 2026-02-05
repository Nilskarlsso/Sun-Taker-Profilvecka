using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 8f;
    public float jumpForce = 14f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    [Header("Health")]
    public int PlayerHealth = 5;
    public float invincibilityTime = 0.8f;

    private int currentHealth;
    private bool isGrounded;
    private bool isInvincible;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        currentHealth = PlayerHealth;
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        CheckGrounded();
    }

    void HandleMovement()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        if (moveInput != 0)
            sr.flipX = moveInput < 0;
    }

    void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void CheckGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );
    }

    public void TakeDamage(int damage, Vector2 knockback)
    {
        if (isInvincible)
            return;

        currentHealth -= damage;

        rb.linearVelocity = Vector2.zero;
        rb.AddForce(knockback, ForceMode2D.Impulse);

        StartCoroutine(Invincibility());

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    System.Collections.IEnumerator Invincibility()
    {
        isInvincible = true;

        // Flash effect
        for (int i = 0; i < 5; i++)
        {
            sr.enabled = false;
            yield return new WaitForSeconds(0.08f);
            sr.enabled = true;
            yield return new WaitForSeconds(0.08f);
        }

        isInvincible = false;
    }

    void Die()
    {
        Debug.Log("Player Died");
        // You can trigger respawn or game over here
        gameObject.SetActive(false);
    }
}