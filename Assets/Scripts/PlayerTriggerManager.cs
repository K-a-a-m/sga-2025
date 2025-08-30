using UnityEngine;

public class PlayerTriggerManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Rigidbody2D playerRB;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trigger"))
        {
                playerRB.linearVelocityY = 0f;
                playerRB.linearVelocityX = 0f;
        }
    }
    // Update is called once per frame
}
