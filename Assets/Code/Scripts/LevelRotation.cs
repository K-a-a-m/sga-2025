using UnityEngine;

public class LevelRotation : MonoBehaviour
{
    [SerializeField] private GameObject playerController;
    [SerializeField] private GameObject cameraController;
    [SerializeField] private int animationDuration;
    [SerializeField] private int gravity;
    public bool willRotate=true;
    private CharacterController0_1 characterController;
    private Rigidbody2D characterRigidbody;
    private bool startTransitionUP = true;
    private bool startTransitionDOWN = true;
    private int currentFrame = 0;//En millisecondes
    private float rotationStep;
    private float currentRotationStep;
    private int currentTremblement;
    private float[] tremblement = {0f,1.5f,3f,1.5f,0f,-1.5f,-3f,-1.5f,0f,1.5f,3f,1.5f,0f,-1.5f,-3f,-1.5f,0f};
    //private float magnitude;
    //private float duration;
    //private Vector3 originalPosition;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = playerController.GetComponent<CharacterController0_1>();//chercher le script CharacterController0_1
        Time.fixedDeltaTime = 0.05f;
        characterRigidbody = playerController.GetComponent<Rigidbody2D>();
        rotationStep = 180f / (animationDuration / 50f);
        //originalPosition = transform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(characterController.stateCameraRotation == 1)//Niveau a l'endroit
        {
            characterRigidbody.gravityScale = gravity;
            playerController.transform.eulerAngles = new Vector3(0,0,0);
            //cameraController.transform.eulerAngles = new Vector3(0,0,0);
            startTransitionUP = true;

        }
        else if(characterController.stateCameraRotation == 2)//rotation caméra vers l'envers
        {
            //Original poistion : x=12.54 y=4.5 z=-10
            //Time.timeScale = 0f;

            //float x = Random.Range(-1f, 1f) * magnitude;
            //float y = Random.Range(-1f, 1f) * magnitude;
            //transform.localPosition = originalPosition + new Vector3(x, y, 0);

            //Time.timeScale = 1f;


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
        else if (characterController.stateCameraRotation == 3)//niveau retoruné
        {
            characterRigidbody.gravityScale = -gravity;
            playerController.transform.eulerAngles = new Vector3(0, 0, 180f);
            //cameraController.transform.eulerAngles = new Vector3(0, 0, 180f);
            startTransitionDOWN = true;
        }
        else if (characterController.stateCameraRotation == 4)//Rotation cam vers l'endroit
        {
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
        else if (characterController.stateCameraRotation == 5)//Tremblement caméra/écran quand c'est up
        {

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
        else if (characterController.stateCameraRotation == 6)//Tremblement caméra/écran quand c'est down
        {

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
