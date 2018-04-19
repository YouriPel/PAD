﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour {

	[Header("First screen")]
	public GameObject MainMenu;
	public GameObject GameScreen;
    public GameObject EndScreen;

	[Header("GameScreen")]
	public GameObject QuestionText;
    public GameObject QuestionAmountText;
	public GameObject UserInputScreen;
	public GameObject AnswerScreen;

	public InputField PlayerInput;
    public int TotalQuestionAmount;
    public int QuestionAmount;
	private String PlayerAnswer;

	public List<String> Answers = new List<String>();
	public GameObject[] AnswerButtons = new GameObject[5];

    public readonly int MAX_ANSWERS = 5;
    public readonly int LAST_ANSWER = 4;
    public readonly int MAX_QUESTION_AMOUNT = 3;
    public readonly int RESET_QUESTION_AMOUNT = 0;

	void Start() {
		// Get all question and answers here
		MainMenu.SetActive(true);
		GameScreen.SetActive (false);
		for (int i = 0; i < AnswerButtons.Length - 1; i++) {
			Answers.Add ("Antwoord " + i);
		}
	}

	public void StartGame() {
		MainMenu.SetActive(false);
		GameScreen.SetActive(true);
        UserInputScreen.SetActive(true);
		AnswerScreen.SetActive(false);
        QuestionText.SetActive(true);
        QuestionAmountText.SetActive(true);
        QuestionAmount = RESET_QUESTION_AMOUNT;
        TotalQuestionAmount = MAX_QUESTION_AMOUNT;
        ShowQuestion();
	}

	public void SendAnswerButton() {
        if (Answers.Count == MAX_ANSWERS) {
            Answers.Remove(Answers[LAST_ANSWER]);
        }
        Answers.Add(PlayerInput.text);
        PlayerInput.text = " ";
        UserInputScreen.SetActive(false);
		AnswerScreen.SetActive(true);
		ShowAnswers();
	}

    public void ShowQuestionAmount() {
        QuestionAmountText.GetComponent<Text>().text = "Vraag " + QuestionAmount + " van de " + TotalQuestionAmount;
    }

	void ShowAnswers() {
		for (int i = 0; i < AnswerButtons.Length; i++) {
			AnswerButtons[i].GetComponentInChildren<Text>().text = Answers[i];
		}
	}

    public void ClickAnswerButton(int knopId)
    {
        // Correct / Incorrect answer must be done here
        // Score can be done here as well

        //The answer button that the user clicked changes color to yellow
        AnswerButtons[knopId].GetComponent<Image>().color = Color.yellow;
        
        StartCoroutine(ShowCorrectAnswer());
    }

    IEnumerator ShowCorrectAnswer()
    {
        //TO DO: De button moet geel blijven zolang the timer nog niet afgelopen
        //is en de overige spelers nog niet antwoord hebben gegeven

        //TEMP: Wait for 1 second
        yield return new WaitForSeconds(1);

        //Change the color of all answer buttons to red
        for (int i = 0; i < AnswerButtons.Length; i++)
        {
            AnswerButtons[i].GetComponent<Image>().color = Color.red;
        }
        //Changes the color of the correct answer button to green
        AnswerButtons[0].GetComponent<Image>().color = Color.green;
        //Shows the correct answerr
        
        QuestionText.GetComponent<Text>().text = "Het goede antwoord was:\n\n" + Answers[0];

        StartCoroutine(NextCorrectAnswer());
    }

    IEnumerator NextCorrectAnswer()
    {
        yield return new WaitForSeconds(5);

        ShowQuestion();

        // Temporary test switch
        AnswerScreen.SetActive(false);
        UserInputScreen.SetActive(true);

        if (QuestionAmount > TotalQuestionAmount)
        {
            GameScreen.SetActive(false);
            AnswerScreen.SetActive(false);
            QuestionText.SetActive(false);
            QuestionAmountText.SetActive(false);
            EndScreen.SetActive(true);
        }
    }

    public void ClickEndGameButton() {
        EndScreen.SetActive(false);
        MainMenu.SetActive(true);
    }

	void ShowQuestion() {
        QuestionAmount++;
        ShowQuestionAmount();
        for (int i = 0; i < AnswerButtons.Length; i++)
        {
            AnswerButtons[i].GetComponent<Image>().color = Color.white;
        }
        // Get question and show it
        // Only unique questions can be shown
    }
}
