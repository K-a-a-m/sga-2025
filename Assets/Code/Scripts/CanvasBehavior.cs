using System.Collections;
using UnityEngine;

public class CanvasBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private CharacterController0_1 characterController;
    [SerializeField] private LevelRotation levelRotation;
    private int currentFrame = 0;
    private bool needToShake = true;
    void Start()
    {
        Time.fixedDeltaTime = 0.05f;
    }


    

// Update is called once per frame
    void FixedUpdate()
    {
        currentFrame++;
        if (currentFrame > 1000 && needToShake)
        {
            Debug.Log("SHAKE");
            levelRotation.willRotate = false;
            characterController.stateCameraRotation = 5;
            needToShake = false;
            Destroy(gameObject);
        }
    }
}
