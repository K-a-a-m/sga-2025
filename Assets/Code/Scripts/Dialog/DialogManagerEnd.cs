using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DialogManagerEnd : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dialogTextEnd;
    [SerializeField] GameObject dialogContainerPanel;
    [SerializeField] TextMeshProUGUI speakerText;
    [SerializeField] private GameObject butterflies;
    [SerializeField] private GameObject canvasBack;
    int dialogIndex = 0;
    public int currentDialog = 1;

        List<Tuple<string, string>> dialogFin = new List<Tuple<string, string>>()
        {
        //new Tuple<string,string> ("Super, j�ai retrouv� mon pinceau magique.", "Milo"),
        new Tuple<string,string> ("Par les pouvoirs qui me sont conférés, je veux que tu restaures le tableau où mon écureuil Albert est enfermé et que tu le libères !", "Milo"),
        new Tuple<string,string> ("Je suis trop content de te revoir, mon petit Albert !", "Milo"),
        new Tuple<string,string> ("Attends, QUOI?", "Milo"),
        new Tuple<string,string> ("T'es un poisson !!!???", "Milo"),
        new Tuple<string,string> ("Bah oui, c'est à cause de ta saleté de sort et ta stupide lubie d'être un magicien de mes deux. (BLOUP, BLOUP)", "Albert"),
        new Tuple<string,string> ("TU ES UN PEINTRE, PAS UN MAGICIEN PATATTE !!!!!! (BLOUP)", "Albert"),
        new Tuple<string,string> ("On fait comment maintenant ?! (BLOUP)", "Albert"),
        new Tuple<string,string> ("T'inquiète, cool Raoul.", "Milo"),
        new Tuple<string,string> ("T'es super mignon en poisson !", "Milo"),
        new Tuple<string,string> ("Je vais en apprendre plus sur la magie et je vais inverser le sort.", "Milo"),
        new Tuple<string,string> ("Mais tu sais, je t�aime comme tu es, peu importe ton apparence.", "Milo"),
        new Tuple<string,string> ("Ils eurent beaucoup de mauvaises aventures et vécurent heureux. Enfin presque...", ""),

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
                    if (dialogIndex < dialogFin.Count)
                    {
                        dialogTextEnd.text = dialogFin[dialogIndex].Item1;
                        speaker = dialogFin[dialogIndex].Item2;
                        dialogIndex++;
                    }
                    else
                    {
                        dialogContainerPanel.SetActive(false);
                        dialogIndex = 0;
                        currentDialog++;
                        butterflies.SetActive(true);
                        canvasBack.SetActive(true);
                        
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

    public void OnClickBackButton()
    {
        SceneManager.LoadScene("Credit");
    }
}
