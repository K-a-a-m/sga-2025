using System;
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
    public void StartGame(int sceneNumber)
    {
        DisplayCreditsStatic.SceneName = nameof(AvailableScenes.PlayerScene);
        animator.SetTrigger("FadeOut");
        //SceneManager.LoadScene("PlayerScene");
    }

    public void ShowCredits()
    {
        panelStartButtons.SetActive(false);
        panelCredits.SetActive(true);
        EventSystem.current.SetSelectedGameObject(defaultCreditsButton);
        DisplayCreditsStatic.DisplayCredits = true;
    }

    public void ShowMainMenuPanel()
    {
        panelCredits.SetActive(false);
        panelStartButtons.SetActive(true);
        EventSystem.current.SetSelectedGameObject(defaultMainMenuButton);
        DisplayCreditsStatic.DisplayCredits = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        DisplayCreditsStatic.SceneName = nameof(AvailableScenes.TitleScreen);
        animator.SetTrigger("FadeOut");
        //SceneManager.LoadScene("TitleScreen");
        
    }
}
