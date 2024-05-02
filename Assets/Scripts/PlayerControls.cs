using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private GatherInput gInput;
    [Header("Movement")]
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private bool facingRight = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Flip();
    }

    void FixedUpdate()
    {
        Move();
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
}
