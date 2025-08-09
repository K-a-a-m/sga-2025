using System.Collections;
using UnityEngine;

public class OrbesControl : MonoBehaviour
{
    [SerializeField] private GameObject playerController;
    [SerializeField] private  OrbeMusicConttroller orbParent;
    [SerializeField] private GameObject orbParentGO;
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
            //orbParentGO.SetActive(false);
            StartCoroutine(DisableOrbParent());
        }

    }

    IEnumerator DisableOrbParent()
    {
        yield return new WaitForSeconds(4.5f);
        orbParentGO.SetActive(false);
    }
}
