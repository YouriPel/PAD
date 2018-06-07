 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class GameScreenScript : MonoBehaviour {

	public GameStateScript gameStateScript;
	public GameObject spelerButtons, answerButtons;
	public GameManagerScript gameManagerScript;
    public ScoreboardScript scoreboardScript;
	private Text questionText;
	public Text[] spelerButtonText = new Text[4];
	public Text[] answerButtonText = new Text[4];
	private int currentPlayerId;
	private int score = 1;

	void Start (){
		spelerButtons.SetActive (true);
		answerButtons.SetActive (false);
		//Gives player name to button
		for (int i = 0; i < gameManagerScript.playerName.Length; i++) {
			spelerButtonText [i].text = gameManagerScript.playerName[i];
		}
	}
	//See which player clicks the button
	public void ClickPlayerButton (int playerId){
		spelerButtons.SetActive (false);
		answerButtons.SetActive (true);
		currentPlayerId = playerId;
		print("Speler  " + currentPlayerId);
	}

	public void SetAnswer(){
	//Set andwoorden uit database in de button
	}

	public void ClickAnswerButton (bool correctAnswer){
		//See if correct answer is clicked
		int playerid = currentPlayerId - 1;
		if (correctAnswer) {
			//Transision polising
			gameManagerScript.score [playerid] += score;
			this.gameObject.SetActive (false);
			gameStateScript.ScoreScreen.SetActive (true);
            scoreboardScript.SetScoreboard();

		} else {
			answerButtons.SetActive (false);
			spelerButtons.SetActive (true);
			spelerButtonText [playerid].transform.parent.gameObject.SetActive (false);
			print ("currentPlayerId: "+playerid);
			currentPlayerId = -1;
		}

	}	
   	 
}
