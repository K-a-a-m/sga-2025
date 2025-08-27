using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameOverScreenManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] GameObject canvas;
    [SerializeField] Animator animator;
    [SerializeField] private GameObject firstButtonSelected;
 
    void Start()
    {
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
            EventSystem.current.SetSelectedGameObject(gameObject.activeSelf ? firstButtonSelected : null);
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
        Debug.Log("LOAD TITLE SCREEN GO Screen Manager");
    }

    public void ReloadScene()
    {
        SceneParametersStatic.AutoSkipDialogsBegin = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
