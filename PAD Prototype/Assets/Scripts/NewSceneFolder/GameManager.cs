using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour {

	[Header("First screen")]
	public GameObject mainMenu;
	public GameObject GameScreen;

	[Header("GameScreen")]
	public GameObject vraagText;
	public GameObject inputObjectAndButton;
	public GameObject answerScreen;

	public InputField playerInput;
	private String playerAnswer;

	public List<String> antwoorden = new List<String>();
	public GameObject[] answerButtons = new GameObject[5];

	void Start(){
		//hier alle vragen en antwoorden ophalen

		mainMenu.SetActive (true);
		GameScreen.SetActive (false);
		for (int i = 0; i < answerButtons.Length - 1; i++) {
			antwoorden.Add ("antwoord "+i);
		}
	}

	public void StartGame(){
		mainMenu.SetActive (false);
		GameScreen.SetActive (true);
		inputObjectAndButton.SetActive (true);
		answerScreen.SetActive (false);
		showQuestion ();
	}

	public void SendAnswerButton(){
		antwoorden.Add (playerInput.text);
		inputObjectAndButton.SetActive (false);
		answerScreen.SetActive (true);
		showAnswers ();

	}

	void showAnswers(){
		for (int i = 0; i < answerButtons.Length; i++) {
			answerButtons [i].GetComponentInChildren<Text>().text = antwoorden[i];
		}
	}

	void showQuestion(){
		//haal question op en tonen
		//Laat alleen question tonen als ie niet eerder is getoond
	}
}
