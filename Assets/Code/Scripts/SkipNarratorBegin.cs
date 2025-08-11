using UnityEngine;
using UnityEngine.InputSystem;

public class SkipNarratorBegin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private AudioSource _audioSourceNarrator;
    [SerializeField] private GameObject panelNarrator;
    [SerializeField] private CanvasBehavior shakeFirstCanvas;
    private InputAction nextDialog;
    void Start()
    {
        nextDialog = InputSystem.actions.FindAction("NextDialog");
    }

    // Update is called once per frame
    void Update()
    {
        if (nextDialog.WasPressedThisFrame())
        {
            panelNarrator.SetActive(false);
            _audioSourceNarrator.Stop();
            shakeFirstCanvas.waitForeShake = 1;
        }
    }
}
