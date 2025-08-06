using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed;

    [SerializeField] private float jumpForce;

    private Rigidbody2D rb;

    private InputAction moveAction;

    private InputAction jumpAction;

    SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        moveAction = InputSystem.actions.FindAction("Move");

        jumpAction = InputSystem.actions.FindAction("Jump");

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();
        rb.linearVelocityX = move.x * moveSpeed;

        if (jumpAction.WasPressedThisFrame())
        {
            rb.AddForceY(jumpForce);
            
        }

        spriteRenderer.flipX = rb.linearVelocityX < 0;
    }
}
