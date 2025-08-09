using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dialogTextEnd;
    [SerializeField] GameObject dialogContainerPanel;
    [SerializeField] TextMeshProUGUI speakerText;

    int dialogIndex = 0;
    public int currentDialog = 1;


        

    List<Tuple<string, string>> dialogWesh = new List<Tuple<string, string>>()
    {
        new Tuple<string,string> ("Wesh, c�est quoi ce bordel !?", "Milo"),
        new Tuple<string,string> ("Oh non, j�ai encore rat�. J�en ai marre !", "Milo"),
        new Tuple<string,string> ("Et il est o� mon pinceau magique ! Non, mais s�rieux !!!", "Milo"),
        new Tuple<string,string> ("Bon, au point o� on en est, autant il y aller comme �a.", "Milo"),
        new Tuple<string,string> ("Let�s go !", "Milo")
    };

    InputAction nextDialog;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogContainerPanel.SetActive(true);
        nextDialog = InputSystem.actions.FindAction("NextDialog");
    }

    // Update is called once per frame
    void Update()
    {
        if(nextDialog.WasPressedThisFrame())
        {
            string speaker = "";
            dialogContainerPanel.SetActive(true);
            switch(currentDialog)
            {
                case 1:
                    if (dialogIndex < dialogWesh.Count)
                    {
                        dialogTextEnd.text = dialogWesh[dialogIndex].Item1;
                        speaker = dialogWesh[dialogIndex].Item2;
                        dialogIndex++;
                    }
                    else
                    {
                        dialogContainerPanel.SetActive(false);
                        dialogIndex = 0;
                        currentDialog = -1;
                    }
                    break;
            default:
                    dialogContainerPanel.SetActive(false);
                    speaker = String.Empty;
                    currentDialog=0;
                    break;


            }   
            speakerText.text = speaker;
        }
    }
}
