using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Collider2D groundCollider;

    private Rigidbody2D rb;
    Animator charachterAnimator;
    SpriteRenderer spriteRenderer;

    private InputAction moveAction; //Bien indiquer le nom de la fonction pour plus tard

    private InputAction jumpAction;

    private int nbJumpsLeft = 0; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        charachterAnimator = GetComponent<Animator>();
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if((groundLayer.value & (1 << other.gameObject.layer)) !=0)
        {
            nbJumpsLeft = 2;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = moveAction.ReadValue<Vector2>(); 
        rb.linearVelocityX = move.x * moveSpeed;

        if (jumpAction.WasPressedThisFrame() && nbJumpsLeft > 0)
        {
            rb.AddForceY(jumpForce * 100);
            nbJumpsLeft--;
        }

        charachterAnimator.SetFloat(name:"speedY", rb.linearVelocityY);
        charachterAnimator.SetFloat(name:"absSpeedX", Mathf.Abs(rb.linearVelocityX));
        charachterAnimator.SetBool(name:"isGrounded", groundCollider.IsTouchingLayers(groundLayer));
        spriteRenderer.flipX = rb.linearVelocityX < 0;
    }
}
