using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuPauseBehavior : MonoBehaviour
{
    
    private InputAction pauseAction;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject player;
    [SerializeField] Animator animator;
   // [SerializeField] private Canvas menuPauseCanvas;
    [SerializeField] private Canvas dialogsCanvas;
    [SerializeField] private GameObject firstButtonSelected;
    private bool isActive = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseAction = InputSystem.actions.FindAction("Pause");
        isActive = false;
        canvas.SetActive(false);
        Time.timeScale = 1;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pauseAction.WasPressedThisFrame())
        {
            BackMenu();
        }

    }

    public void BackMenu()
    {
        
        isActive = !isActive;
        canvas.SetActive(isActive);
        player.GetComponent<CharacterController0_1>().enabled = !isActive;
        EventSystem.current.SetSelectedGameObject(isActive ? firstButtonSelected : null);
        
        Time.timeScale = isActive ? 0 : 1;
    }

    public void LoadTitleScreen()
    {
        Time.timeScale = 1;
        
        //menuPauseCanvas.sortingOrder = 0;
        //dialogsCanvas.sortingOrder = 1;
        SceneParametersStatic.SceneName = nameof(AvailableScenes.TitleScreen);
        SceneParametersStatic.DisplayCredits = false;
        animator.SetTrigger("FadeOut");
        canvas.SetActive(false);
    }
}
