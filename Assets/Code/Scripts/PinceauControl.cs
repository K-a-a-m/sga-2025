using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PinceauControl : MonoBehaviour
{
    private Collider2D colliderTrigger;
    private bool hasDetect = true;
    [SerializeField] private DialogManager dialogManager;
    [SerializeField] private Animator animator;
    private Vector3 amount = new Vector3(.5f, .5f, .5f);
    private float time = 1.5f;
    private void Start()
    {
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
        if (colliderTrigger.tag == "Player" && hasDetect)
        {
            EnterFadeOut();
            hasDetect = false;
            dialogManager.currentDialog = 2;
        }

    }

    private void EnterFadeOut()
    {
        
        DisplayCreditsStatic.SceneName = nameof(AvailableScenes.FinalScreenLayered);
        animator.SetTrigger("FadeOut");
       // StartCoroutine(OnFadeOutComplete());
    }
}
