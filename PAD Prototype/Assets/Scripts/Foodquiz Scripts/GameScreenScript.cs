 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class GameScreenScript : MonoBehaviour {

	public GameStateScript gameStateScript;
	public GameObject spelerButtons, answerButtons, scoreboardScreen;
	public GameManagerScript gameManagerScript;
    public ScoreboardScript scoreboardScript;
    public TimerScript timerScript;
    public GameObject timer;
    public List<Player> players = new List<Player>();
    private Text questionText;
	public Text[] spelerButtonText = new Text[4];
	public Text[] answerButtonText = new Text[4];
	private int currentPlayerId;
	private int score = 1;
    private int currentScore;

    private readonly int EQUALISE_VALUE = 1;

    void Start (){
		spelerButtons.SetActive (true);
		answerButtons.SetActive (false);
        //Gives player name to button
        for (int i = EQUALISE_VALUE; i < scoreboardScript.GetPlayerAmount() + EQUALISE_VALUE; i++) {
			spelerButtonText[i - EQUALISE_VALUE].text = scoreboardScript.GetPlayer(i).GetName();
		}
	}
	//See which player clicks the button
	public void ClickPlayerButton (int playerId){
		spelerButtons.SetActive (false);
		answerButtons.SetActive (true);
		currentPlayerId = playerId;
		print("Speler  " + currentPlayerId);

        timer.SetActive(true);
        timerScript.StartTimer();
    }

	public void SetAnswer(){
	//Set andwoorden uit database in de button
	}

	public void ClickAnswerButton (bool correctAnswer){
		//See if correct answer is clicked
		int playerid = currentPlayerId;
		if (correctAnswer) { //if the answer is correct
            //Transision polising
            scoreboardScript.GetPlayer(playerid).UpdateScore();
			//gameManagerScript.score [playerid] += score;
			this.gameObject.SetActive (false);
			gameStateScript.ScoreScreen.SetActive (true);
            scoreboardScript.SetScoreboard();
		} else {//if the answer is not correct
            timerScript.ResetTimer();//////////////////////////////////////
            answerButtons.SetActive (false);
			spelerButtons.SetActive (true);
			spelerButtonText [playerid-1].transform.parent.gameObject.SetActive (false);
			print ("currentPlayerId: "+playerid);
			currentPlayerId = -1;
		}

	}	

    public void EndScoreBoard() {
        for(int i=0; i<spelerButtonText.Length; i++)
        {
            spelerButtonText[i].transform.parent.gameObject.SetActive(true);
        }

        gameStateScript.ScoreScreen.SetActive(false);
        gameStateScript.GameScreen.SetActive(true);
        answerButtons.SetActive(false);
        spelerButtons.SetActive(true);
    }
   	 
}
