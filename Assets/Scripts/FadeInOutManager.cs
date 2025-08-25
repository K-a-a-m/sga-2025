using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInOutManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnFadeOutComplete()
    {
        Debug.Log("FADING OUT");
        SceneManager.LoadScene(SceneParametersStatic.SceneName);
    }
}
