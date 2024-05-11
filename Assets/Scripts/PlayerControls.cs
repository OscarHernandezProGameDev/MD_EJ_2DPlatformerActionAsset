using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private GatherInput gInput;
    private Animator animator;

    [Header("Movement")]
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private bool facingRight = true;

    [Header("Jump")]
    [SerializeField] private float jumpForce;

    [Header("Ground Check")]
    [SerializeField] private float rayLength;
    [SerializeField] private Transform leftPoint;
    [SerializeField] private Transform rightPoint;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Flip();
        SetAnimatorValues();
    }

    void FixedUpdate()
    {
        GroundCheck();
        Move();
        Jump();
    }

    private void Move()
    {
        rb.velocity = new Vector2(gInput.valueX * speed, rb.velocity.y);
    }

    private void Flip()
    {
        if (facingRight && gInput.valueX < 0)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            facingRight = !facingRight;
        }
        else if (!facingRight && gInput.valueX > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            facingRight = !facingRight;
        }
    }

    private void Jump()
    {
        if ((gInput.tryToJump))
        {
            if (isGrounded)
                rb.velocity = new Vector2(speed * gInput.valueX, jumpForce);
            gInput.tryToJump = false;
        }
    }

    private void GroundCheck()
    {
        RaycastHit2D hitLeft = Physics2D.Raycast(leftPoint.position, Vector2.down, rayLength, groundLayer);
        RaycastHit2D hitRight = Physics2D.Raycast(rightPoint.position, Vector2.down, rayLength, groundLayer);

        isGrounded = hitLeft || hitRight;
    }

    private void SetAnimatorValues()
    {
        //animator.SetFloat("speedX", Mathf.Abs(gInput.valueX));
        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("speedY", rb.velocity.y);
        animator.SetFloat("speedX", Mathf.Abs(rb.velocity.x));
    }
}
