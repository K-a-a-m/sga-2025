using NUnit.Framework.Constraints;
using UnityEngine;

public class OrbeMusicConttroller : MonoBehaviour
{
    
    [SerializeField] private GameObject player;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClipNarrator;
    private Collider2D colliderTrigger;
    [SerializeField] private AudioManager audioManager;
    public bool hasEnter = false;
    [SerializeField] private int radiusTrigger = 15;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        colliderTrigger = GetComponent<Collider2D>();
        audioSource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasEnter)
        {
            float distanceVolOrb = (radiusTrigger - (Vector2.Distance( player.transform.position ,transform.position))) / radiusTrigger;
            audioSource.volume = distanceVolOrb; 
            audioManager.ASource.volume = (1 - distanceVolOrb) * 0.8f;
        }
    }
    
    
    private void OnTriggerEnter2D(Collider2D colliderTrigger)
    {
        if (colliderTrigger.tag == "Player")
        {
            hasEnter = true;
            //audioManager.ASource.Stop();
            audioSource.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D colliderTrigger)
    {
        if (colliderTrigger.tag == "Player")
        {
            hasEnter = false;
            audioSource.Stop();
            audioManager.ASource.volume = 0.8f;
            //audioManager.ASource.Play();
        }
    }

    public void ChangeAudioClip()
    {
        audioSource.Stop();
        audioSource.clip = audioClipNarrator;
        
        audioSource.volume = 1f;
        audioSource.Play();
        audioSource.loop = false;
        
        Debug.Log("CHANGE AUDIO CLIP");
    }
}
