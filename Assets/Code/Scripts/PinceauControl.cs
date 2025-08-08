using UnityEngine;
using UnityEngine.SceneManagement;

public class PinceauControl : MonoBehaviour
{
    private Collider2D colliderTrigger;
    


    private void Start()
    {
        colliderTrigger = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D colliderTrigger)
    {
        if (colliderTrigger.tag == "Player")
        {
            Debug.Log("pinceau");
            //SceneManager.LoadScene(sceneName);
        }

    }
}
