 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class GameScreenScript : MonoBehaviour {

	public GameObject spelerButtons, answerButtons, scoreboardScreen;
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
    private int questionAmount = 0;
    private int count = 0;

    private readonly int EQUALISE_VALUE = 1;

    public AudioSource incorrectSound;
    public AudioSource correctSound;
    public AudioSource timeSound;

    public int[] disabledPlayersById = new int[4];

    private Vector2[] answerButtonStartPos = new Vector2[4];
    public List<Vector2> DiffPos = new List<Vector2>();

    void Start (){
		spelerButtons.SetActive (true);
		answerButtons.SetActive (false);

        //Gives player name to button
        for (int i = EQUALISE_VALUE; i < scoreboardScript.GetPlayerAmount() + EQUALISE_VALUE; i++) {
			spelerButtonText[i - EQUALISE_VALUE].text = scoreboardScript.GetPlayer(i).GetName();
		}

        //save begin position of answerbutton
        for (int i = 0; i < answerButtonText.Length; i++)
        {
            RectTransform parentPos = answerButtonText[i].transform.parent.gameObject.GetComponent<RectTransform>();
            answerButtonStartPos[i] = parentPos.anchoredPosition;
        }
        InitDiffPos();
        SetAnswer();
        ShowQuestion();
    }

    void InitDiffPos()
    {
        DiffPos.Add(new Vector2(-195, -400));
        DiffPos.Add(new Vector2(195, -400));
        DiffPos.Add(new Vector2(-195, 135));
        DiffPos.Add(new Vector2(195,  135));
    }



    void ShowQuestion()
    {
        questionAmount++;
        questionAmountText.text = questionAmount + " / 5";

        int rndPlayer = (int)UnityEngine.Random.Range(0, spelerButtonText.Length);

        questionText.text = spelerButtonText[rndPlayer].text + questionScript.questions[count];
        count++;
    }

	//See which player clicks the button
	public void ClickPlayerButton (int playerId){
		currentPlayerId = playerId;
		//print("Speler  " + currentPlayerId);
    }

    public void ChosenButton(GameObject button)
    {
        for (int i = 0; i < spelerButtonText.Length; i++)
        {
            GameObject parent = spelerButtonText[i].transform.parent.gameObject;
            Button chosenButton = parent.GetComponent<Button>();
            if (parent != button)
            {
                chosenButton.interactable = false;
            }
        }
        StartCoroutine("ChosenPlayerTimer");
    }

	private IEnumerator ChosenPlayerTimer()
	{
		yield return new WaitForSeconds(1);
		spelerButtons.SetActive(false);
		answerButtons.SetActive(true);
		timer.SetActive(true);
		timerScript.StartTimer();
		playSound("timerPlay");
	}

    void EnableInteractable()
    {
        for (int i = 0; i < spelerButtonText.Length; i++)
        {
			//enable player buttons
            GameObject parent = spelerButtonText[i].transform.parent.gameObject;
            Button chosenButton = parent.GetComponent<Button>();
            chosenButton.interactable = true;

			//enable answer buttons
			GameObject Answerparent = answerButtonText[i].transform.parent.gameObject;
			Button chosenAnswerButton = Answerparent.GetComponent<Button>();
			chosenAnswerButton.interactable = true;
        }
    }

    

	public void ChosenAnswerButton(GameObject button)
	{
		for (int i = 0; i < answerButtonText.Length; i++)
		{
			GameObject parent = answerButtonText[i].transform.parent.gameObject;
			Button chosenButton = parent.GetComponent<Button>();
			if (parent != button)
			{
				chosenButton.interactable = false;
			}
		}
		IEnumerator coroutine;
		if (button.gameObject.name == "AnswerButton4"){
			coroutine = ChosenAnswerTimer (true);
		}
		else{
			coroutine = ChosenAnswerTimer (false);
		}
		StartCoroutine(coroutine);
	}

	private IEnumerator ChosenAnswerTimer(bool Answer)
	{
		yield return new WaitForSeconds(1);
		ClickAnswerButton (Answer);
	}

	public void SetAnswer(){
        int amountOfAnswers = 4; //Int to select the next 4 answers in the list.
        for (int i = 0; i < answerButtonText.Length; i++)
        {
            int whatAnswer = i + (amountOfAnswers * count);
            answerButtonText[i].text = questionScript.answers[whatAnswer];
            RectTransform parentPos = answerButtonText[i].transform.parent.gameObject.GetComponent<RectTransform>();

            int rndPos = (int)UnityEngine.Random.Range(0, DiffPos.Count);
            //print("object "+i+" heeft "+ DiffPos[rndPos]);
            parentPos.anchoredPosition = DiffPos[rndPos];
            DiffPos.RemoveAt(rndPos);
        }
	}

    public void ClickAnswerButton (bool correctAnswer){
		//See if correct answer is clicked
		int playerid = currentPlayerId;
        timerScript.ResetTimer();
		timer.SetActive(false);
		playSound("timerStop");

        EnableInteractable();
        if (correctAnswer) { //if the answer is correct
            playSound("correct");
            scoreboardScript.GetPlayer(playerid).UpdateScore();
            ShowScoreBoard();
        }
        else
        {//if the answer is not correct
            playSound("incorrect");
			//print ("incorrect antwoord");
            answerButtons.SetActive (false);
			spelerButtons.SetActive (true);
            spelerButtonText [playerid-1].transform.parent.gameObject.SetActive (false);
            //disabledPlayersById[incorrectPlayers] = playerid - 1;

			playSound("incorrect");
			incorrectPlayers++;
			print("incorrectPlayers: "+incorrectPlayers);

            //If all 4 players answered incorrectly. Go to scoreboard screen.
            if (incorrectPlayers == 4)
            {
                ShowScoreBoard();
                playSound("timerStop");
            }
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

    public void EndScoreBoard()
    {
        for (int i=0; i<spelerButtonText.Length; i++)
        {
            spelerButtonText[i].transform.parent.gameObject.SetActive(true);
        }
        
		if (questionAmount == 5) {
			gameStateScript.EndScreen.SetActive (true);
            gameStateScript.ScoreScreen.SetActive(false);
		}
        else
		{
			incorrectPlayers = 0;
            InitDiffPos();
            SetAnswer();
            ShowQuestion();
			EnableInteractable ();
            gameStateScript.GameScreen.SetActive(true);
            gameStateScript.ScoreScreen.SetActive(false);
			answerButtons.SetActive(false);
			spelerButtons.SetActive(true);
        }

    }
   	 
}
