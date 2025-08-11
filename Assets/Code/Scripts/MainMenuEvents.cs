using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuEvents : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject panelStartButtons;
    [SerializeField] private GameObject panelCredits;
    
    public void StartGame(int sceneNumber)
    {
        SceneManager.LoadScene("PlayerScene");
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
        SceneManager.LoadScene("TitleScreen");
    }
}
