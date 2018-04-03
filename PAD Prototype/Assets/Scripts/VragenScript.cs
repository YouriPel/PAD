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
	public string[] previousQuestion;

	public Button[] answerButton = new Button[5];

    int questionNumber, correctAnswer, temp_sol;

	System.Random rnd = new System.Random();

	public GameObject GameManager;
	private UIScript UI;

    void Start ()
    {
		UI = GameManager.GetComponent<UIScript> ();
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
        int rndQuestion = rnd.Next(0, 4);
		quizDB = Regex.Split(lines[rndQuestion], "~");
        
		/*for(int i=0; i<lines.Length; i++){
			
			print ("quizDB: "+quizDB[i]);
		}*/

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
				//vier volgende vragen hiero
            }
        }
        sr.Close();

		previousQuestion = new String[4];
		/*print ("Questions: "+questions.Count);
		print ("answers: "+answers.Count);

		for(int i=0; i<answers.Count; i++)
		{
			print ("antwoord: "+answers[i]);
		}*/
    }

    // Display question on screen
    public void ShowQuestion()
    {
		questionField.text = questions[questionNumber];
		questionNumber++;
		correctAnswer = rnd.Next (0, 4); //1 van de 4 antwoorden is goed
		print("correctAnswer: "+correctAnswer);
		//print ("wat is de vraag: "+questions[questionNumber]);
        
		inputAnswer.text = "";
    }


	
    public void SetAnswer()
    {
		print ("setanswer");
        customAnswer = inputAnswer.text;
       //print(customAnswer);
        
        /*System.Random rnd = new System.Random();
        int index = rnd.Next(0, questions.Count);
        //print(index);
        
        questionField.text = questions[index];*/
        //print(questions[index]);

		answerButton [4].GetComponentInChildren<Text> ().text = customAnswer;

		for(int i=0; i < answerButton.Length-1; i++){
			answerButton [i].GetComponentInChildren<Text> ().text = answers [i+temp_sol];
			//print ("answerbtn tekst: "+answerButton [i].GetComponentInChildren<Text> ().text);
			//print ("answer: "+answerButton[i]);
		}
        
        // Hier moeten de antwoorden worden gelinkt aan de knoppen op willekeurige volgorde
        // Houd er rekening mee dat een van de antwoorden de goede moet zijn & dat antwoorden van de array per 4 gesorteerd zijn op vraag
        // Dus answers[0] t/m answers[3] = question[0], answers[4] t/m answers[7] = question[1]
    }

	public void ClickAnswerButton(int val){
		for(int i=0; i<answerButton.Length; i++){
			answerButton [i].GetComponent<Image> ().color = Color.red;
		}
		answerButton [correctAnswer].GetComponent<Image> ().color = Color.green;

        StartCoroutine (NextCorrectAnswer());
	}

    IEnumerator NextCorrectAnswer()
    {
        questionField.text = questionField.text + "\n\n" + 
            "Het goede antwoord was: " + 
            answerButton[correctAnswer].GetComponentInChildren<Text>().text;

        yield return new WaitForSeconds(3);

        StartCoroutine(NextQuestion());
    }

    IEnumerator NextQuestion(){
		yield return new WaitForSeconds (3);
		for(int i=0; i<answerButton.Length; i++){
			answerButton [i].GetComponent<Image> ().color = Color.white;
		}
		ShowNextQuestion ();
	}

	void ShowNextQuestion(){
		temp_sol += 4;
		UI.questionFrame.SetActive(true);
		UI.answerFrame.SetActive(false);
		InitVragen ();
		ShowQuestion ();
	}

	/*
    public void Shuffle()
    {
        for (int iRandom = 0; iRandom < answerButton.Length; iRandom++)
        {
            
        }
    }*/

}
