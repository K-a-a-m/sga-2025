using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class CharacterController0_1 : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Collider2D groundCollider;
   // private float horizontal = -Input.GetAxisRaw("Horizontal"); // Inverse gauche/droite

    public GameObject sceneBackground;
    public int stateCameraRotation = 1;

    private Rigidbody2D rb;
    //Animator charachterAnimator;
    SpriteRenderer spriteRenderer;

    private InputAction moveAction; //Bien indiquer le nom de la fonction pour plus tard
    
    private InputAction jumpAction;

    private InputAction interactionAction;

    private int nbJumpsLeft = 0; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //charachterAnimator = GetComponent<Animator>();
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        interactionAction = InputSystem.actions.FindAction("Interact");

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
        //Debug.Log("stateCameraRotation : " + stateCameraRotation);
        

        //charachterAnimator.SetFloat(name:"speedY", rb.linearVelocityY);
        //charachterAnimator.SetFloat(name:"absSpeedX", Mathf.Abs(rb.linearVelocityX));
        //charachterAnimator.SetBool(name:"isGrounded", groundCollider.IsTouchingLayers(groundLayer));
        spriteRenderer.flipX = rb.linearVelocityX < 0;
        Debug.Log("stateCameraRotation : " + stateCameraRotation);
        if(interactionAction.WasPressedThisFrame())
        {
            if (stateCameraRotation == 1)
            {
                stateCameraRotation = 2;
                //horizontal = -horizontal;
            }
            else if(stateCameraRotation == 3) 
            {
                stateCameraRotation = 2;
            }
        }
        if (stateCameraRotation == 3)
        {
            MoveCharacter(-1);
            JumpCharacter(-1);
        } else
        {
            MoveCharacter(1);
            JumpCharacter(1);
        }
    }

    private void JumpCharacter(int jumpDir)
    {
      //  Debug.Log("nbJumpsLeft : " + nbJumpsLeft);
        

        if (jumpAction.WasPressedThisFrame() && nbJumpsLeft > 0)
        {
            //Debug.Log("jumpAction : " + jumpDir * jumpForce * 100);
            rb.AddForceY(jumpDir * jumpForce * 100);
            nbJumpsLeft--;
        }
    }

    private void MoveCharacter(int moveDir)
    {
        Vector2 move = moveAction.ReadValue<Vector2>();
        rb.linearVelocityX = moveDir * move.x * moveSpeed;
    }
}
