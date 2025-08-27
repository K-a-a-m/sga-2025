using UnityEngine;

public class StartScreenBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    
    [SerializeField] private MainMenuEvents _mainMenuEvents;
    
    void Start()
    {
        CameraRotation.stateCameraRotation = 1;
        SceneParametersStatic.AutoSkipDialogsBegin =  false;
        if (SceneParametersStatic.DisplayCredits)
        {
            _mainMenuEvents.ShowCredits();
        }
        else
        {
            _mainMenuEvents.ShowMainMenuPanel();
        }

        
    }

}
