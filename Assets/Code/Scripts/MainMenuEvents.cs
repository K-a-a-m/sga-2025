using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuEvents : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void StartGame()
    {
        Debug.Log("START GAME");
    }

    public void ShowCredits()
    {
        Debug.Log("SHOW CREDITS");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT GAME");
    }
}
