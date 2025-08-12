using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuEvents : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject panelStartButtons;
    [SerializeField] private GameObject panelCredits;
    [SerializeField] private Animator animator;
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
        DisplayCreditsStatic.DisplayCredits = true;
    }

    public void ShowMainMenuPanel()
    {
        panelCredits.SetActive(false);
        panelStartButtons.SetActive(true);
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
