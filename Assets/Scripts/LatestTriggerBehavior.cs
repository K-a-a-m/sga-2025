using System.Collections.Generic;
using UnityEngine;

public class LatestTriggerBehavior : MonoBehaviour
{
    [SerializeField] private List<GameObject> _triggers;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ResetTriggers();   
        }
    }

    public void ResetTriggers()
    {
        foreach (GameObject trigger in _triggers)
        {
            trigger.SetActive(true);
        }   
    }
}
