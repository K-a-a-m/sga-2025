using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dialogText;
    List<string> dialogFin = new List<string>()
    {
        "Super, j’ai retrouvé mon pinceau magique.",
        "Par les pouvoirs qui me sont conférés, je veux que tu restaures le tableau où m’on écureuil Albert est enfermé et que tu le libères !",
        "Je suis trop content de te revoir, mon petit Albert !",
        "Attends, QUOI?",
        "T'es un poisson !!!???",
        "Bah oui, c’est à cause de ta saleté de sort et ta stupide lubie d’être un magicien de mes deux. (BLOUB, BLOUB)",
        "TU ES UN PEINTRE, PAS UN MAGICIEN PATATTE !!!!!! (BLOUB)",
        "On fait comment maintenant ? (BLOUB)",
        "T’inquiète, cool Raoul.",
        "T’es super mignon en poisson !",
        "Je vais en apprendre plus sur la magie et je vais inverser le sort.",
        "Mais tu sais, je t’aime comme tu es, peu importe ton apparence.",

    };
    
    List<string> startText = new List<string>()
    {
        "Dans un pays lointain, au fin fond d’une forêt enchantée, habitent un jeune peintre nommé Milo et son écureuil de compagnie appelé Albert. Ce jeune homme cache un secret important, c’est un apprenti magicien. Il vit dans une petite maisonnette campagnarde entouré de voisins particuliers. Ce sont toutes des créatures fantastiques, principalement des farfadets et des fées.",
        "Un jour, un farfadet malicieux s’introduit dans leur maison et jette un sortilège à Albert l’écureuil. Albert est désormais emprisonné dans une toile. Mais le petit farfadet ne s’est point arrêté là. Il a caché toutes les couleurs nécessaires pour reconstituer la peinture de la toile. Milo s’introduit par un sort dans la toile pour récupérer ses couleurs afin qu’il la restaure et sauve Albert. Une fois à l’intérieur, il décide de jeter un sortilège de pivotement délibéré.",
        

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
