using UnityEngine;

public class OrbesControl : MonoBehaviour
{
    [SerializeField] private GameObject playerController;
    [SerializeField] private  OrbeMusicConttroller orbParent;
    private Collider2D colliderTrigger;
    private CharacterController0_1 characterController;
    private bool hasDetect = true;

    private void Start()
    {
        characterController = playerController.GetComponent<CharacterController0_1>();
        colliderTrigger = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D colliderTrigger)
    {
        if (colliderTrigger.tag == "Player" && hasDetect)
        {
            hasDetect = false;
            characterController.orbesNumber++;
            characterController.checkPoint = true;
            orbParent.ChangeAudioClip();
            
            Destroy(gameObject);
            
        }

    }
}
