using System.Collections;
using UnityEngine;

public class TriggerControl : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Rigidbody2D playerRB;
    private Collider2D colliderTrigger;
    private CharacterController0_1 characterController;
    [SerializeField] private bool disabledAfterTrigger = true;
    private void Start()
    {
        playerRB = player.GetComponent<Rigidbody2D>();
        characterController = player.GetComponent<CharacterController0_1>();
        colliderTrigger = GetComponent<Collider2D>();
        GetComponent<Renderer>().enabled = false;

    }
    private void OnTriggerEnter2D(Collider2D colliderTrigger)
    {
       /* if (colliderTrigger.tag == "Player")
        {
            if (characterController.stateCameraRotation == 1)
            {
                characterController.stateCameraRotation = 5;
            }
            else if (characterController.stateCameraRotation == 3)
            {
                characterController.stateCameraRotation = 6;
            }
            gameObject.SetActive(!disabledAfterTrigger);
        } */
        
        if (colliderTrigger.tag == "Player")
        {
            //characterController.enabled = false;
            if (CameraRotation.stateCameraRotation == 1)
            {
                CameraRotation.stateCameraRotation = 5;
            }
            else if (CameraRotation.stateCameraRotation == 3)
            {
                CameraRotation.stateCameraRotation = 6;
            }
            gameObject.SetActive(!disabledAfterTrigger);
            
        }

    }
}

