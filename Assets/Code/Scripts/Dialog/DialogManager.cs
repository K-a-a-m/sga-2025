using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dialogText;
    List<string> dialogFin = new List<string>()
    {
        "Super, j�ai retrouv� mon pinceau magique.",
        "Par les pouvoirs qui me sont conf�r�s, je veux que tu restaures le tableau o� m�on �cureuil Albert est enferm� et que tu le lib�res !",
        "Je suis trop content de te revoir, mon petit Albert !",
        "Attends, QUOI?",
        "T'es un poisson !!!???",
        "Bah oui, c�est � cause de ta salet� de sort et ta stupide lubie d��tre un magicien de mes deux. (BLOUB, BLOUB)",
        "TU ES UN PEINTRE, PAS UN MAGICIEN PATATTE !!!!!! (BLOUB)",
        "On fait comment maintenant ? (BLOUB)",
        "T�inqui�te, cool Raoul.",
        "T�es super mignon en poisson !",
        "Je vais en apprendre plus sur la magie et je vais inverser le sort.",
        "Mais tu sais, je t�aime comme tu es, peu importe ton apparence.",

    };
    
    List<string> startText = new List<string>()
    {
        "Dans un pays lointain, au fin fond d�une for�t enchant�e, habitent un jeune peintre nomm� Milo et son �cureuil de compagnie appel� Albert. Ce jeune homme cache un secret important, c�est un apprenti magicien. Il vit dans une petite maisonnette campagnarde entour� de voisins particuliers. Ce sont toutes des cr�atures fantastiques, principalement des farfadets et des f�es.",
        "Un jour, un farfadet malicieux s�introduit dans leur maison et jette un sortil�ge � Albert l��cureuil. Albert est d�sormais emprisonn� dans une toile. Mais le petit farfadet ne s�est point arr�t� l�. Il a cach� toutes les couleurs n�cessaires pour reconstituer la peinture de la toile. Milo s�introduit par un sort dans la toile pour r�cup�rer ses couleurs afin qu�il la restaure et sauve Albert. Une fois � l�int�rieur, il d�cide de jeter un sortil�ge de pivotement d�lib�r�.",
        

    };



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogText.text = "J'aime les chiens";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
