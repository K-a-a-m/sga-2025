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


        List<Tuple<string, string>> dialogFin = new List<Tuple<string, string>>()
        {
        new Tuple<string,string> ("Super, j�ai retrouv� mon pinceau magique.", "Milo"),
        new Tuple<string,string> ("Par les pouvoirs qui me sont conf�r�s, je veux que tu restaures le tableau o� m�on �cureuil Albert est enferm� et que tu le lib�res !", "Milo"),
        new Tuple<string,string> ("Je suis trop content de te revoir, mon petit Albert !", "Milo"),
        new Tuple<string,string> ("Attends, QUOI?", "Milo"),
        new Tuple<string,string> ("T'es un poisson !!!???", "Milo"),
        new Tuple<string,string> ("Bah oui, c�est � cause de ta salet� de sort et ta stupide lubie d��tre un magicien de mes deux. (BLOUP, BLOUP)", "Albert"),
        new Tuple<string,string> ("TU ES UN PEINTRE, PAS UN MAGICIEN PATATTE !!!!!! (BLOUP)", "Albert"),
        new Tuple<string,string> ("On fait comment maintenant ?! (BLOUP)", "Albert"),
        new Tuple<string,string> ("T�inqui�te, cool Raoul.", "Milo"),
        new Tuple<string,string> ("T�es super mignon en poisson !", "Milo"),
        new Tuple<string,string> ("Je vais en apprendre plus sur la magie et je vais inverser le sort.", "Milo"),
        new Tuple<string,string> ("Mais tu sais, je t�aime comme tu es, peu importe ton apparence.", "Milo"),

    };

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
                case 2:
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
