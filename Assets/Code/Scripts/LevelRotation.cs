using UnityEngine;

public class LevelRotation : MonoBehaviour
{
    [SerializeField] private GameObject playerController;
    [SerializeField] private GameObject cameraController;
    [SerializeField] private int animationDuration;
    private CharacterController0_1 characterController;
    private Rigidbody2D characterRigidbody;
    private bool startTransitionUP = true;
    private int currentFrame = 0;//En millisecondes
    private float rotationStep;
    private float currentRotationStep;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = playerController.GetComponent<CharacterController0_1>();//chercher le script CharacterController0_1
        Time.fixedDeltaTime = 0.05f;
        characterRigidbody = playerController.GetComponent<Rigidbody2D>();
        rotationStep = 180f / (animationDuration / 50f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(characterController.stateCameraRotation == 1)
        {
            characterRigidbody.gravityScale = 1f;
            playerController.transform.eulerAngles = new Vector3(0,0,0);
            cameraController.transform.eulerAngles = new Vector3(0,0,0);

        }
        else if(characterController.stateCameraRotation == 2)
        {
            Debug.Log("stateCameraRotation : " + characterController.stateCameraRotation);
            if(startTransitionUP)
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
                cameraController.transform.eulerAngles = new Vector3(0, 0, currentRotationStep);
                Debug.Log(rotationStep); Debug.Log(currentFrame);
            }
            else
            {
                characterController.stateCameraRotation = 3;
            }
        }
        else if (characterController.stateCameraRotation == 3)
        {
            characterRigidbody.gravityScale = -1f;
            playerController.transform.eulerAngles = new Vector3(0, 0, 180f);
            cameraController.transform.eulerAngles = new Vector3(0, 0, 180f);
        }

    }
}
