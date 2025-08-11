using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;


public class OrbesControl : MonoBehaviour
{
    [SerializeField] private GameObject playerController;
    [SerializeField] private  OrbeMusicConttroller orbParent;
    [SerializeField] private GameObject orbParentGO;
    [SerializeField] private GameObject orbUI;
    [SerializeField] private SpriteRenderer orbSprite;
    [SerializeField] private string colorName = "ORBCOLOR";
    [SerializeField] private LatestTriggerBehavior ltb;
    private float orbTransparancy = .3f;
    private Vector3 amount = new Vector3(.5f, .5f, .5f);
    private float time = 1.5f;
    private Collider2D colliderTrigger;
    private CharacterController0_1 characterController;
    private bool hasDetect = true;
    
    private void Start()
    {
        characterController = playerController.GetComponent<CharacterController0_1>();
        colliderTrigger = GetComponent<Collider2D>();
        float randomTime = Random.Range(time - 0.5f, time + 0.5f);
        iTween.PunchScale(gameObject, iTween.Hash(
            "amount", amount,
            "time", randomTime,
            "looptype", iTween.LoopType.loop
        ));
        
    }
    private void OnTriggerEnter2D(Collider2D colliderTrigger)
    {
        if (colliderTrigger.CompareTag("Player"))
        {
            characterController.checkPoint = true;
            if (!hasDetect) return;
            hasDetect = false;
            characterController.orbesNumber++;

            orbParent.ChangeAudioClip();
            
            //Destroy(gameObject);
            iTween.Stop(gameObject);
            Color spriteColor = orbSprite.color;
            spriteColor.a = orbTransparancy;
            orbSprite.color = spriteColor;
            orbUI.SetActive(true);
            iTween.ScaleTo(orbUI,iTween.Hash("x", 1, "y", 1, "time", 1.2f));
            if (colorName.ToUpper() == "MAGENTA")
            {
                ltb.ResetTriggers();
            }
            //orbParentGO.SetActive(false);
            //StartCoroutine(DisableOrbParent());
        }

    }

    
}
