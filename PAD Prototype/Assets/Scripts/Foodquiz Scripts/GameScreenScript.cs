 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using DatabaseCheck;

public class GameScreenScript : MonoBehaviour {

	public GameObject spelerButtons, answerButtons, scoreboardScreen, nextButton;
    public GameObject timer;

    public QuestionScript questionScript;
    public GameStateScript gameStateScript;
    public ScoreboardScript scoreboardScript;
    public TimerScript timerScript;

    public List<Player> players = new List<Player>();

    public Text questionText;
	public Text[] spelerButtonText = new Text[4];
	public Text[] answerButtonText = new Text[4];
    public Text questionAmountText;

    private int currentPlayerId;
    private int incorrectPlayers;
    private int currentScore;
    private int questionAmount = 1;
    private int count = 0;

    private readonly int EQUALISE_VALUE = 1;

    MySQL mysql = new MySQL();

    public AudioSource incorrectSound;
    public AudioSource correctSound;
    public AudioSource timeSound;

    void Start (){
		spelerButtons.SetActive (true);
		answerButtons.SetActive (false);
        mysql.ConnectToMySQL();
        mysql.OpenConnection();

        //Gives player name to button
        for (int i = EQUALISE_VALUE; i < scoreboardScript.GetPlayerAmount() + EQUALISE_VALUE; i++) {
			spelerButtonText[i - EQUALISE_VALUE].text = scoreboardScript.GetPlayer(i).GetName();
		}

        ShowQuestion();
    }

    void ShowQuestion()
    {
        questionAmountText.text = questionAmount + " / 5";

        int rndPlayer = (int)UnityEngine.Random.Range(0, spelerButtonText.Length);

        questionText.text = spelerButtonText[rndPlayer].text + questionScript.questions[count];
        count++;
    }

	//See which player clicks the button
	public void ClickPlayerButton (int playerId){
		spelerButtons.SetActive (false);
		answerButtons.SetActive (true);
		currentPlayerId = playerId;
		print("Speler  " + currentPlayerId);
        //questionText.text = questions[count];
        //count++;
        timer.SetActive(true);
        timerScript.StartTimer();
        playSound("timerPlay");
    }

	public void SetAnswer(){
        int amountOfAnswers = 4; //Int to select the next 4 answers in the list.
        for(int i=0; i<answerButtonText.Length; i++)
        {
            int whatAnswer = i + (amountOfAnswers * questionAmount);
            answerButtonText[i].text = questionScript.answers[whatAnswer];
            //4de antwoord altijd goed
        }
	}

	public void ClickAnswerButton (bool correctAnswer){
		//See if correct answer is clicked
		int playerid = currentPlayerId;
        timerScript.ResetTimer();
        if (correctAnswer) { //if the answer is correct
            playSound("correct");
            scoreboardScript.GetPlayer(playerid).UpdateScore();

            ShowScoreBoard();
        }
        else
        {//if the answer is not correct
            playSound("incorrect");
            answerButtons.SetActive (false);
			spelerButtons.SetActive (true);
			spelerButtonText [playerid-1].transform.parent.gameObject.SetActive (false);
            incorrectPlayers++;

            //If all 4 players answered incorrectly. Go to scoreboard screen.
            if (incorrectPlayers == 4)
            {
                ShowScoreBoard();
                playSound("timerStop");
            }

            print ("currentPlayerId: "+playerid);
			currentPlayerId = -1;
        }
    }

    void ShowScoreBoard()
    {
        this.gameObject.SetActive(false);
        gameStateScript.ScoreScreen.SetActive(true);
        scoreboardScript.SetScoreboard();
        timer.SetActive(false);
    }

    public void playSound(String path)
    {
        switch(path)
        {
            case "correct":
                correctSound.Play();
                timeSound.Stop();
                break;
            case "incorrect":
                incorrectSound.Play();
                break;
            case "timerPlay":
                timeSound.Play();
                break;
            case "timerStop":
                timeSound.Stop();
                break;
            default:
                break;
        }
    }

    public void EndScoreBoard() {
        for(int i=0; i<spelerButtonText.Length; i++)
        {
            spelerButtonText[i].transform.parent.gameObject.SetActive(true);
        }



		if (questionAmount == 5) {
			gameStateScript.EndScreen.SetActive (true);
			gameStateScript.ScoreScreen.SetActive (true);
			gameStateScript.GameScreen.SetActive (false);
			nextButton.SetActive (false);
			answerButtons.SetActive (false);
			spelerButtons.SetActive (false);
		} else {
			questionAmount++;
            //print ("Aantal vragen geweest: " + questionAmount);
            ShowQuestion();

            gameStateScript.ScoreScreen.SetActive(false);
			gameStateScript.GameScreen.SetActive(true);
			answerButtons.SetActive(false);
			spelerButtons.SetActive(true);
		}

    }
   	 
}
