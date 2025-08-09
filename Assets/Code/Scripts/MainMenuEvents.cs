using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuEvents : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void StartGame(int sceneNumber)
    {
        Debug.Log("START GAME");
        SceneManager.LoadScene("PlayerScene");
    }

    public void ShowCredits()
    {
        Debug.Log("SHOW CREDITS");
        SceneManager.LoadScene("Credit");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT GAME");
        Application.Quit();
    }

    public void MainMenu()
    {
        Debug.Log("MAIN MENU");
        SceneManager.LoadScene("TitleScreen");
    }
}
