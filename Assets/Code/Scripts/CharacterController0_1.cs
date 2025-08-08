using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
//UnityEngine.Debug.Log // avec system diagnostics

public class CharacterController0_1 : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask outOfPlayLayer;
    [SerializeField] private Collider2D groundCollider;
    [SerializeField] private GameObject pinceauGoal;
    [SerializeField] private GameObject bounderyUp;
    [SerializeField] private GameObject bounderyDown;
    [SerializeField] private int targetOrbes;
    [SerializeField] private AudioClip JumpSFX;
    [SerializeField] private AudioClip LandSFX;
    [SerializeField] private AudioClip OrbeSFX;
    [SerializeField] private AudioClip RotationSFX;
    [SerializeField] private AudioClip MarcheSFX;
    // private float horizontal = -Input.GetAxisRaw("Horizontal"); // Inverse gauche/droite

    public GameObject sceneBackground;
    public int stateCameraRotation = 1;
    public int orbesNumber = 0;
    private Vector3 respawnPos;
    private int respawnState;
    private Quaternion respawnRot;
    private Collider2D bounderyUpCollider;
    private Collider2D bounderyDownCollider;
    private AudioSource audioSource;



    private Rigidbody2D rb;
    Animator charachterAnimator;
    SpriteRenderer spriteRenderer;

    private InputAction moveAction; //Bien indiquer le nom de la fonction pour plus tard
    
    private InputAction jumpAction;

    private InputAction interactionAction;

    public int nbJumpsLeft = 0;
    public bool checkPoint = false;

    TriggerControl[] controllers;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        interactionAction = InputSystem.actions.FindAction("Interact");
        charachterAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        bounderyUpCollider = bounderyUp.GetComponent<Collider2D>();
        bounderyDownCollider = bounderyDown.GetComponent<Collider2D>();
        respawnPos = this.transform.position;
        respawnRot = this.transform.rotation;
        respawnState = stateCameraRotation;
        audioSource = GetComponent<AudioSource>();
        controllers = GameObject.FindObjectsByType<TriggerControl>(FindObjectsSortMode.None);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if((groundLayer.value & (1 << other.gameObject.layer)) !=0)
        {
            nbJumpsLeft = 2;
        } 

        if ((outOfPlayLayer.value & (1 << other.gameObject.layer)) != 0)
        {
            this.transform.position = respawnPos;
            this.transform.rotation = respawnRot;
            stateCameraRotation = respawnState;
            foreach (TriggerControl control in controllers)
            {
                control.gameObject.SetActive(true);

            }
        }

    }

    // Update is called once per frame
    void Update()
    {


        charachterAnimator.SetFloat(name: "speedY", rb.linearVelocityY);
        charachterAnimator.SetFloat(name: "absSpeedX", Mathf.Abs(rb.linearVelocityX));
        charachterAnimator.SetBool(name: "isGrounded", groundCollider.IsTouchingLayers(groundLayer));


        if (stateCameraRotation == 3)
        {
            MoveCharacter(-1);
            JumpCharacter(-1);
            spriteRenderer.flipX = rb.linearVelocityX > -0.1;

        }
        else if (stateCameraRotation == 1)
        {
            MoveCharacter(1);
            JumpCharacter(1);
            spriteRenderer.flipX = rb.linearVelocityX < -0.1;
        }

        if (orbesNumber == targetOrbes)//changer cette valeur avec nombre placée dans scene
        {
            pinceauGoal.SetActive(true);
        }

        if (checkPoint)
        {
            checkPoint = false;
            respawnPos = this.transform.position;
            respawnRot = this.transform.rotation;
            respawnState = stateCameraRotation;
        }


    }

    private void JumpCharacter(int jumpDir)
    {
        

        if (jumpAction.WasPressedThisFrame() && nbJumpsLeft > 0)
        {

            rb.linearVelocityY = 0;

            rb.AddForceY(jumpDir * jumpForce * 50);

            nbJumpsLeft--;

            audioSource.PlayOneShot(JumpSFX);
        }
    }

    private void MoveCharacter(int moveDir)
    {
        Vector2 move = moveAction.ReadValue<Vector2>();
        rb.linearVelocityX = moveDir * move.x * moveSpeed;
        if (Mathf.Abs(rb.linearVelocityX) > 0.01 && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(MarcheSFX);
        }
    }


}

