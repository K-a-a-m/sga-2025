using UnityEngine;
using UnityEngine.SceneManagement;

public class PinceauControl : MonoBehaviour
{
    private Collider2D colliderTrigger;
    private bool hasDetect = true;
    [SerializeField] private DialogManager dialogManager;

    private void Start()
    {
        colliderTrigger = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D colliderTrigger)
    {
        if (colliderTrigger.tag == "Player" && hasDetect)
        {
            SceneManager.LoadScene("FinalScreen");
            hasDetect = false;
            dialogManager.currentDialog = 2;
        }

    }
}
