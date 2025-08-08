using UnityEngine;

public class TriggerControl : MonoBehaviour
{
    [SerializeField] private GameObject playerController;
    private Collider2D colliderTrigger;
    private CharacterController0_1 characterController;

    private void Start()
    {
        characterController = playerController.GetComponent<CharacterController0_1>();
        colliderTrigger = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D colliderTrigger)
    {
        if (colliderTrigger.tag == "Player")
        {
            if (characterController.stateCameraRotation == 1)
            {
                characterController.stateCameraRotation = 5;
            }
            else if (characterController.stateCameraRotation == 3)
            {
                characterController.stateCameraRotation = 6;
            }
            Destroy(gameObject);
        }

    }
}
