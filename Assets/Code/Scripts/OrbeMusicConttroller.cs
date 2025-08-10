using System.Collections;
using NUnit.Framework.Constraints;
using UnityEngine;

public class OrbeMusicConttroller : MonoBehaviour
{
    
    [SerializeField] private GameObject player;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClipNarrator;
    private Collider2D _colliderTrigger;
    [SerializeField] private AudioManager audioManager;
    public bool hasEnter = false;
    private bool hasAudioChanged = false;
    [SerializeField] private int radiusTrigger = 15;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _colliderTrigger = GetComponent<Collider2D>();
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
        if (colliderTrigger.CompareTag("Player"))
        {
            hasEnter = true;
            //audioManager.ASource.Stop();
            audioSource.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D colliderTrigger)
    {
        if (colliderTrigger.CompareTag("Player") && !hasAudioChanged)
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
        hasAudioChanged =  true;
        hasEnter = false;
        audioSource.volume = 1f;
        audioSource.Play();
        audioSource.loop = false;
        _colliderTrigger.enabled = false;
        
        //
        //Debug.Log("CHANGE AUDIO CLIP");
        StartCoroutine(RaiseAudioManagerVolume());
    }



    IEnumerator RaiseAudioManagerVolume()
    {
        yield return new WaitForSeconds(4f);
        audioManager.ASource.volume = 0.8f;
    }
}
