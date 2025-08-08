using NUnit.Framework.Constraints;
using UnityEngine;

public class OrbeMusicConttroller : MonoBehaviour
{
    
    [SerializeField] private GameObject player;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClipNarrator;
    private Collider2D colliderTrigger;
    [SerializeField] private AudioManager audioManager;
    private bool hasEnter = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        colliderTrigger = GetComponent<Collider2D>();
    }
    
    private void OnTriggerEnter2D(Collider2D colliderTrigger)
    {
        if (colliderTrigger.tag == "Player" && !hasEnter)
        {
            hasEnter = true;
            audioManager.ASource.Stop();
            audioSource.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D colliderTrigger)
    {
        if (colliderTrigger.tag == "Player" && hasEnter)
        {
            hasEnter = false;
            audioSource.Stop();
            audioManager.ASource.Play();
        }
    }

    public void ChangeAudioClip()
    {
        audioSource.Stop();
        audioSource.clip = audioClipNarrator;
        audioSource.Play();
    }
}
