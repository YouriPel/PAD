 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using DatabaseCheck;

public class GameScreenScript : MonoBehaviour {

	public GameStateScript gameStateScript;
	public GameObject spelerButtons, answerButtons, scoreboardScreen, nextButton;
	public GameManagerScript gameManagerScript;
    public ScoreboardScript scoreboardScript;
    public TimerScript timerScript;
    public GameObject timer;
    public List<Player> players = new List<Player>();
    private Text questionText;
	public Text[] spelerButtonText = new Text[4];
	public Text[] answerButtonText = new Text[4];
	private int currentPlayerId;
    private int incorrectPlayers;
    private int currentScore;
    MySQL mysql = new MySQL();
    private readonly int EQUALISE_VALUE = 1;
	public Text questionAmountText;
	private int questionAmount = 1;
    public List<String> questions = new List<String>();
    public List<String> answers = new List<String>();
    public List<String> facts = new List<String>();
    public int count = 0;

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
		questionAmountText.text = questionAmount + " / 5";

        questions.Add(spelerButtonText[1]+"heeft zonneallergie, welke vitamine krijgt ze nu niet binnen ?");
        questions.Add(spelerButtonText[0]+"is gecrashed met het vliegtuig en is de enige overlevende Hoeveel dagen kan een mens zonder eten ?");
        questions.Add(spelerButtonText[2]+"drinkt een halve liter bier in de nachtclub. Hoeveel kJ energie krijgt hij hiervan?");
        questions.Add(spelerButtonText[0]+"krijgt 293 kcal binnen na het eten van een product. Welk product kan dit zijn");
        questions.Add(spelerButtonText[3]+"heeft gisteren een Big Mac gegeten (503 kcal). Hoeveel minuten moet hij/zij hardlopen (12 km/h) om deze weer te verbranden");
    }
    

	


	//See which player clicks the button
	public void ClickPlayerButton (int playerId){
		spelerButtons.SetActive (false);
		answerButtons.SetActive (true);
		currentPlayerId = playerId;
		print("Speler  " + currentPlayerId);
        questionText.text = questions[count];
        count++;
        timer.SetActive(true);
        timerScript.StartTimer();
        playSound("timerPlay");
    }

	public void SetAnswer(){
	//Set andwoorden uit database in de button
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
			questionAmountText.text = questionAmount + " / 5";
			gameStateScript.ScoreScreen.SetActive(false);
			gameStateScript.GameScreen.SetActive(true);
			answerButtons.SetActive(false);
			spelerButtons.SetActive(true);
		}

    }
   	 
}
