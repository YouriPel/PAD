using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QuestionScript : MonoBehaviour {

    public List<String> questions = new List<String>();
    public List<String> answers = new List<String>();
    public List<String> facts = new List<String>();
    // Use this for initialization
    void Start () {
        AddQuestions();
        AddAnswers();
        AddFacts();
    }
    
    //Add the questions in the questions list
	void AddQuestions()
    {
        questions.Add(" heeft zonneallergie, welke vitamine krijgt hij/zij nu niet binnen?");
        questions.Add(" heeft een sappige mango. Hoeveel gram suiker bevat zijn/haar mango?");//
        questions.Add(" drinkt een halve liter bier in de nachtclub. Hoeveel kJ energie krijgt hij/zij hiervan?");
        questions.Add(" krijgt 293 kcal binnen na het eten van een product. Welk product kan dit zijn?");
        questions.Add(" eet drie appels om energie van te krijgen. Wat kan hij/zij ook eten voor dezelfde hoeveelheid energie?");//
    }

    //Add the answers in the answers list
    void AddAnswers()
    {
        answers.Add("Vitamine A");
        answers.Add("Vitamine B");
        answers.Add("Vitamine C");
        answers.Add("Vitamine D");//Goed antwoord

        answers.Add("11,2 gram");
        answers.Add("13 gram");
        answers.Add("11 gram");
        answers.Add("12,2 gram");//Goed antwoord

        answers.Add("625 KJ");
        answers.Add("515 KJ");
        answers.Add("400 KJ");
        answers.Add("875 KJ");//Goed antwoord

        answers.Add("Een avocado");
        answers.Add("Een ananas");
        answers.Add("Een appel");
        answers.Add("Een knakworst");//Goed antwoord

        answers.Add("1 stuk watermeloen");
        answers.Add("3 sinaasappel");
        answers.Add("3 mandarijnen");
        answers.Add("3 peren");//Goed antwoord
    }

    //Add the facts in the facts list
    void AddFacts()
    {
        facts.Add("Vitamine D is van belang voor sterke botten.");
        facts.Add("Het zal je misschien verbazen, maar mango’s kunnen een ontstekingsremmend werken.");
        facts.Add("Het proosten van een glas bier of wijn stamt uit het tijdperk van de Romeinen. Maar waar is deze gewoonte eigenlijk door ontstaan? Blijkbaar wantrouwde men elkaar, doordat veel Romeinen elkaar vergiftigden. Door ruw te proosten werd er een hoop drank uitgewisseld tussen de glazen. Hierdoor was de kans op vergiftiging een stuk kleiner.");
        facts.Add("Wist je dat een knakworst ongeveer 1/5 van de geadviseerde hoeveelheid eiwitten per dag bevat?");
        facts.Add("Wist 80% van een appel bestaat uit water?");

    }
}
