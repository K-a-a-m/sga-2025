using UnityEngine;

public class LevelRotation : MonoBehaviour
{
    [SerializeField] private GameObject playerController;
    [SerializeField] private GameObject cameraController;
    [SerializeField] private int animationDuration;
    [SerializeField] private AudioClip RotationSFX;
    [SerializeField] private AudioClip shakeSFX;
    public bool willRotate=true;
    [SerializeField] private float GravityScale;
    private CharacterController0_1 characterController;
    private Rigidbody2D characterRigidbody;
    private bool startTransitionUP = true;
    private bool startTransitionDOWN = true;
    private int currentFrame = 0;//En millisecondes
    private float rotationStep;
    private float currentRotationStep;
    private int currentTremblement;
    private float[] tremblement = {0f,1.5f,3f,1.5f,0f,-1.5f,-3f,-1.5f,0f,1.5f,3f,1.5f,0f,-1.5f,-3f,-1.5f,0f};
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = playerController.GetComponent<CharacterController0_1>();//chercher le script CharacterController0_1
        Time.fixedDeltaTime = 0.05f;
        characterRigidbody = playerController.GetComponent<Rigidbody2D>();
        rotationStep = 180f / (animationDuration / 50f);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(characterController.stateCameraRotation == 1)//Niveau a l'endroit
        {
            characterRigidbody.gravityScale = GravityScale;
            playerController.transform.eulerAngles = new Vector3(0,0,0);
            //cameraController.transform.eulerAngles = new Vector3(0,0,0);
            startTransitionUP = true;

        }
        else if(characterController.stateCameraRotation == 2)//rotation caméra vers l'envers
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(RotationSFX);
            }

            characterController.nbJumpsLeft = 0;
            if (startTransitionUP)
            {
                currentFrame = 0;
                startTransitionUP = false;
                currentRotationStep = 0;
                characterRigidbody.gravityScale = 0;
            }

            currentFrame++;
            if (currentFrame < (animationDuration / 50))
            {
                currentRotationStep = rotationStep * currentFrame;
                //cameraController.transform.eulerAngles = new Vector3(0, 0, currentRotationStep);
                playerController.transform.eulerAngles = new Vector3(0, 0, currentRotationStep);
            }
            else
            {
                characterController.stateCameraRotation = 3;
            }
        }
        else if (characterController.stateCameraRotation == 3)//niveau retorun�
        {

            characterRigidbody.gravityScale = -GravityScale;
            playerController.transform.eulerAngles = new Vector3(0, 0, 180f);
            //cameraController.transform.eulerAngles = new Vector3(0, 0, 180f);
            startTransitionDOWN = true;
        }
        else if (characterController.stateCameraRotation == 4)//Rotation cam vers l'endroit
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(RotationSFX);
            }
            characterController.nbJumpsLeft = 0;
            if (startTransitionDOWN)
            {
                currentFrame = 0;
                startTransitionDOWN = false;
                currentRotationStep = 0;
                characterRigidbody.gravityScale = 0;
            }

            currentFrame++;
            if (currentFrame < (animationDuration / 50))
            {
                currentRotationStep = 180 - (rotationStep * currentFrame);
                playerController.transform.eulerAngles = new Vector3(0, 0, currentRotationStep);
            }
            else
            {
                characterController.stateCameraRotation = 1;
            }
           

        }
        else if (characterController.stateCameraRotation == 5)//Tremblement cam�ra/�cran quand c'est up
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(shakeSFX);
            }
            characterController.nbJumpsLeft = 0;
            if (startTransitionUP)
            {
                startTransitionUP = false;
                currentTremblement = 0;
            }

            currentTremblement++;
            if (currentTremblement < tremblement.Length)
            {
                cameraController.transform.eulerAngles = new Vector3(0, 0, tremblement[currentTremblement]);
            }
            else
            {
                startTransitionUP = true;
                if (willRotate)
                {
                    characterController.stateCameraRotation = 2;
                }
                else
                {
                    characterController.stateCameraRotation = 1;
                }
            }

        }
        else if (characterController.stateCameraRotation == 6)//Tremblement cam�ra/�cran quand c'est down
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(shakeSFX);
            }
            characterController.nbJumpsLeft = 0;
            if (startTransitionDOWN)
            {
                startTransitionDOWN = false;
                currentTremblement = 0;
            }

            currentTremblement++;
            if (currentTremblement < tremblement.Length)
            {
                cameraController.transform.eulerAngles = new Vector3(0, 0, 180-tremblement[currentTremblement]);
            }
            else
            {
                startTransitionDOWN = true;
                if (willRotate)
                {
                    characterController.stateCameraRotation = 4;
                }
                else
                {
                    characterController.stateCameraRotation = 3;
                }
            }

        }


    }
}
