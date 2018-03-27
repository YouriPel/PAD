using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class VragenScript : MonoBehaviour
{
    public Text questionField;
    public InputField inputAnswer;

    public string customAnswer;
    public List<String> answers;
    public List<String> questions;

    public string[] quizDB;

	public Button[] answerButton = new Button[5];

	int questionNumber = 0;

    void Start ()
    {
        InitVragen();
    }

    void InitVragen()
    {
        // Getting the questions and answers from a txt file
        string path = "Assets/VragenLijst.txt";
        StreamReader sr = new StreamReader(path);

        // Putting all values in an array
        string alleVragen = sr.ReadToEnd();
		//print ("alleVragen: "+alleVragen);
        string[] lines = Regex.Split(alleVragen, ";");

        // Putting the questions randomly in an array
        System.Random rnd = new System.Random();
        int rndQuestion = rnd.Next(0, lines.Length);
        quizDB = Regex.Split(lines[rndQuestion], "~");
		//print ("quizDB: "+quizDB);

        // Assigning every 5th value as a question and the others as answers
        for (int iLine = 0; iLine < quizDB.Length; iLine++)
        {
            if(iLine % 5 == 0)
            {
				questions.Add(quizDB[iLine]);
            } 
			else
            {
				answers.Add (quizDB [iLine]);
            }
        }
        sr.Close();
		ShowQuestion ();

		print ("Questions: "+questions.Count);
		print ("answers: "+answers.Count);

		for(int i=0; i<answers.Count; i++)
		{
			print ("antwoord: "+answers[i]);
		}
    }

    // Display question on screen
    public void ShowQuestion()
    {
        questionField.text = questions[questionNumber];
		//print ("wat is de vraag: "+questions[questionNumber]);
        questionNumber++;
    }
	
    public void SetAnswer()
    {
        customAnswer = inputAnswer.text;
       //print(customAnswer);
        
        System.Random rnd = new System.Random();
        int index = rnd.Next(0, questions.Count);
        //print(index);
        
        questionField.text = questions[index];
        //print(questions[index]);

		answerButton [4].GetComponentInChildren<Text> ().text = customAnswer;

		for(int i=0; i < answerButton.Length; i++){
			if (answerButton [i].GetComponentInChildren<Text> ().text == "") {
				answerButton [i].GetComponentInChildren<Text> ().text = answers [i];
			}
			print ("answer: "+answerButton[i]);
		}


        // Hier moeten de antwoorden worden gelinkt aan de knoppen op willekeurige volgorde
        // Houd er rekening mee dat een van de antwoorden de goede moet zijn & dat antwoorden van de array per 4 gesorteerd zijn op vraag
        // Dus answers[0] t/m answers[3] = question[0], answers[4] t/m answers[7] = question[1]
    }


}
