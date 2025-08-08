using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   [SerializeField] private List<AudioClip> _audioClips;
   [SerializeField] private List<GameObject> _orbs;
   private int currentIndexTrack = 0;
   [SerializeField] private CharacterController0_1 player;
   [SerializeField] private AudioSource audioSource;

   public AudioSource ASource
   {
       get { return audioSource; }
   }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentIndexTrack != player.orbesNumber)
        {
            PlayTrack();
            currentIndexTrack++;
        }
    }

    private void PlayTrack()
    {
        audioSource.clip = _audioClips[currentIndexTrack];
        audioSource.Play();
    }
}
