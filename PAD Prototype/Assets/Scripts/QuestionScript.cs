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
        questions.Add(" heeft zonneallergie, welke vitamine krijgt ze nu niet binnen ?");
        questions.Add(" is gecrashed met het vliegtuig en is de enige overlevende Hoeveel dagen kan een mens zonder eten ?");
        questions.Add(" drinkt een halve liter bier in de nachtclub. Hoeveel kJ energie krijgt hij hiervan?");
        questions.Add(" krijgt 293 kcal binnen na het eten van een product. Welk product kan dit zijn");
        questions.Add(" heeft gisteren een Big Mac gegeten (503 kcal). Hoeveel minuten moet hij/zij hardlopen (12 km/h) om deze weer te verbranden");
    }

    //Add the answers in the answers list
    void AddAnswers()
    {

    }

    //Add the facts in the facts list
    void AddFacts()
    {

    }
}
