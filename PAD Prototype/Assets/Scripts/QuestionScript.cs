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
        questions.Add(" heeft zonneallergie, welke vitamine krijgt ze nu niet binnen?");
        questions.Add(" is gecrashed met het vliegtuig en is de enige overlevende Hoeveel dagen kan een mens zonder eten?");
        questions.Add(" drinkt een halve liter bier in de nachtclub. Hoeveel kJ energie krijgt hij hiervan?");
        questions.Add(" krijgt 293 kcal binnen na het eten van een product. Welk product kan dit zijn?");
        questions.Add(" heeft gisteren een Big Mac gegeten (503 kcal). Hoeveel minuten moet hij/zij hardlopen (12 km/h) om deze weer te verbranden?");
    }

    //Add the answers in the answers list
    void AddAnswers()
    {
        answers.Add("Vitamine A");
        answers.Add("Vitamine B");
        answers.Add("Vitamine C");
        answers.Add("Vitamine D");
        answers.Add("14 dagen");
        answers.Add("6 dagen");
        answers.Add("28 dagen");
        answers.Add("35 dagen");
        answers.Add("625 KJ");
        answers.Add("515 KJ");
        answers.Add("400 KJ");
        answers.Add("875 KJ");
        answers.Add("Een Avocado");
        answers.Add("Een Ananas");
        answers.Add("Een Appel");
        answers.Add("Een knakworst");
        answers.Add("27 minuten");
        answers.Add("13 minuten");
        answers.Add("36 minuten");
        answers.Add("12 minuten");
    }

    //Add the facts in the facts list
    void AddFacts()
    {
        facts.Add("Als je schaduw langer is dan jezelf, kun je wel naar buiten gaan, maar je huid zal geen vitamine D maken, hoe zonnig het ook is.");
        facts.Add("Van je zintuigen is je zicht het eerste wat je verliest als je sterft, Je gehoor staat op de laatste plek.");
        facts.Add("Het proosten van een glas bier of wijn stamt uit het tijdperk van de Romeinen. Maar waar is deze gewoonte eigenlijk door ontstaan? Blijkbaar wantrouwde men elkaar, doordat veel Romeinen elkaar vergiftigden. Door ruw te proosten werd er een hoop drank uitgewisseld tussen de glazen. Hierdoor was de kans op vergiftiging een stuk kleiner.");
        facts.Add("Wist je dat het record voor de meeste broodjes worst eten in 10 minuten 68 broodjes is.");
        facts.Add("Om een centimeter van je taille af te halen moet je 1,8 kilogram vet verbranden. Dat is ongeveer zesduizend calorieën, oftewel zo’n acht uur hardlopen.");

    }
}
