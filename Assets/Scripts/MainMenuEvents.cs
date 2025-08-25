using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class MainMenuEvents : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject panelStartButtons;
    [SerializeField] private GameObject panelCredits;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject defaultMainMenuButton;
    [SerializeField] private GameObject defaultCreditsButton;
    [SerializeField] private GameObject levelHardToggle;
    public void Start()
    {
        if (SceneParametersStatic.SceneName == nameof(AvailableScenes.TitleScreen))
        {
            SceneParametersStatic.SceneName = nameof(AvailableScenes.PlayerScene);
        }
    }

    public void StartGame()
    {
        //SceneParametersStatic.SceneName = nameof(AvailableScenes.PlayerScene);
        animator.SetTrigger("FadeOut");
        //SceneManager.LoadScene("PlayerScene");
    }

    public void ShowCredits()
    {
        panelStartButtons.SetActive(false);
        panelCredits.SetActive(true);
        EventSystem.current.SetSelectedGameObject(defaultCreditsButton);
        SceneParametersStatic.DisplayCredits = true;
    }

    public void ShowMainMenuPanel()
    {
        panelCredits.SetActive(false);
        panelStartButtons.SetActive(true);
        EventSystem.current.SetSelectedGameObject(defaultMainMenuButton);
        SceneParametersStatic.DisplayCredits = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneParametersStatic.SceneName = nameof(AvailableScenes.TitleScreen);
        animator.SetTrigger("FadeOut");
        //SceneManager.LoadScene("TitleScreen");
        
    }

    public void ChangePlayerScene()
    {
        if (SceneParametersStatic.SceneName == nameof(AvailableScenes.PlayerScene))
        {
            SceneParametersStatic.SceneName = nameof(AvailableScenes.PlayerSceneExpert);
        }
        else if (SceneParametersStatic.SceneName == nameof(AvailableScenes.PlayerSceneExpert))
        {
            SceneParametersStatic.SceneName = nameof(AvailableScenes.PlayerScene);
        }
    }

    public void ShowLevelHardToggle()
    {
        levelHardToggle.SetActive(!levelHardToggle.activeSelf);
    }
}
