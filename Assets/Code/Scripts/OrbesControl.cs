using UnityEngine;

public class OrbesControl : MonoBehaviour
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
            characterController.orbesNumber++;
            Debug.Log("Orbes Nuber : " + characterController.orbesNumber);
            Destroy(gameObject);
        }

    }
}
