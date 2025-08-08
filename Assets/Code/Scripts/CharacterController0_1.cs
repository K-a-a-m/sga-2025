using System;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Diagnostics;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
//UnityEngine.Debug.Log // avec system diagnostics

public class CharacterController0_1 : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Collider2D groundCollider;
    [SerializeField] private GameObject pinceauGoal;
   // private float horizontal = -Input.GetAxisRaw("Horizontal"); // Inverse gauche/droite

    public GameObject sceneBackground;
    public int stateCameraRotation = 1;
    public int orbesNumber = 0;

    private Rigidbody2D rb;
    Animator charachterAnimator;
    SpriteRenderer spriteRenderer;

    private InputAction moveAction; //Bien indiquer le nom de la fonction pour plus tard
    
    private InputAction jumpAction;

    private InputAction interactionAction;

    public int nbJumpsLeft = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        interactionAction = InputSystem.actions.FindAction("Interact");
        charachterAnimator = GetComponent<Animator>();
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


        charachterAnimator.SetFloat(name:"speedY", rb.linearVelocityY);
        charachterAnimator.SetFloat(name:"absSpeedX", Mathf.Abs(rb.linearVelocityX));
        charachterAnimator.SetBool(name:"isGrounded", groundCollider.IsTouchingLayers(groundLayer));




            //spriteRenderer.flipX = rb.linearVelocityX < -0.1;
       // if (interactionAction.WasPressedThisFrame())
        //{
          //  if (stateCameraRotation == 1)
            //{
              //  stateCameraRotation = 5;
                //horizontal = -horizontal;
            //}
            //else if(stateCameraRotation == 3) 
            //{
              //  stateCameraRotation = 6;
            //}
        //}

        if (stateCameraRotation == 3)
        {
            MoveCharacter(-1);
            JumpCharacter(-1);
            spriteRenderer.flipX = rb.linearVelocityX > -0.1;

        } else if (stateCameraRotation == 1)
        {
            MoveCharacter(1);
            JumpCharacter(1);
            spriteRenderer.flipX = rb.linearVelocityX < -0.1;
        }

        if (orbesNumber == 1)//changer cette valeur avec nombre placée dans scene
        {
            //Debug.Log();
            pinceauGoal.SetActive(true);
        }

    }

    private void JumpCharacter(int jumpDir)
    {
        

        if (jumpAction.WasPressedThisFrame() && nbJumpsLeft > 0)
        {

            //Debug.Log("jumpAction : " + jumpDir * jumpForce * 100);
            rb.linearVelocityY = 0;

            rb.AddForceY(jumpDir * jumpForce * 50);

            nbJumpsLeft--;
        }
    }

    private void MoveCharacter(int moveDir)
    {
        Vector2 move = moveAction.ReadValue<Vector2>();
        rb.linearVelocityX = moveDir * move.x * moveSpeed;
    }
}
