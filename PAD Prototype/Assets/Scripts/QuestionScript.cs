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
        facts.Add("Wist je dat Vitamine D van belang is voor sterke botten?");
        facts.Add("Wist je dat mango’s ontstekingsremmend kunnen werken?");
        facts.Add("Wist je dat proosten stamt uit de Romeinse tijd? Om te bewijzen dat er geen gif in een glas zat werd er ruw geproost.");
        facts.Add("Wist je dat een knakworst ongeveer 1/5 van de geadviseerde hoeveelheid eiwitten per dag bevat?");
        facts.Add("Wist je dat 80% van een appel bestaat uit water?");

    }
}
