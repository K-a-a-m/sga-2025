using System.Collections;
using UnityEngine;

public class CanvasBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private CharacterController0_1 characterController;
    [SerializeField] private LevelRotation levelRotation;
    [SerializeField] private DialogManager dialogManager;
    public int waitForeShake = 1000;
    private int currentFrame = 0;
    private bool needToShake = true;


    void Start()
    {
        Time.fixedDeltaTime = 0.05f;
        characterController.enabled = false; // SET BACK TO FALSE
    }


    

// Update is called once per frame
    void FixedUpdate()
    {
        currentFrame++; 
        if (currentFrame > waitForeShake && needToShake) //Value = 1000
        {
            levelRotation.willRotate = false;
            dialogManager.CanContinueDialogs = true;
            //characterController.stateCameraRotation = 5;
            CameraRotation.stateCameraRotation = 5;
            needToShake = false;
            Destroy(gameObject);
            
        }
        /*else
        {
            characterController.rb.linearVelocityY = 0f;
            characterController.rb.linearVelocityX = 0f;
        } */
    }
}
