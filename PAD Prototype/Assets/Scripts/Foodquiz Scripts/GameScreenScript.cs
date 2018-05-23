 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class GameScreenScript : MonoBehaviour {

	public GameStateScript gameStateScript;

	public GameObject QuestionText;
	public GameObject QuestionAmountText;
	public GameObject UserInputScreen;
	public GameObject AnswerScreen;
    public GameObject GameScreen;
    public GameObject EndScreen;
    public GameObject ScoreScreen;

    public InputField PlayerInput;
	public int TotalQuestionAmount;
	public int QuestionAmount;
	private String PlayerAnswer;

    string[] questionArray = new string[3];
    string[] answerInfo = new string[3];
    public List<String> Answers = new List<String>();
	public GameObject[] AnswerButtons = new GameObject[5];

	public readonly int MAX_ANSWERS = 5;
	public readonly int LAST_ANSWER = 4;
	public readonly int MAX_QUESTION_AMOUNT = 3;
	public readonly int RESET_QUESTION_AMOUNT = 0;

	void Start() {

		gameStateScript = GameObject.Find ("GameManager").GetComponent<GameStateScript> ();

		// Get all question and answers here
		Answers.Add("15 minuten");
        Answers.Add("12,2");
        Answers.Add("Vitamine B");
        Answers.Add("450");

        questionArray[0] = "Trudy heeft een sappige mango. Hoeveel gram suiker bevat Trudy’s mango ?";
        questionArray[1] = "Jaap heeft een kater. Welke vitamine kan hij het beste nemen ?";
        questionArray[2] = "Jaap en Trudy hebben een date bij de McDonalds, ze bestellen beide een McChicken. Hoeveel calorieën krijgen ze totaal binnen ?";

        answerInfo[0] = "Wanneer je mango’s eet krijg je helaas niet alleen maar goede stoffen binnen.\n Mango bevat namelijk ook 12,2 gram fruitsuiker (fructose) per portie van 82,5 gram.\n Fructose kan gewichtsverlies in de weg staan als je er te veel van binnenkrijgt.";
        answerInfo[1] = "Vitamine B breekt alcohol af.\n Melkproducten, vleeswaren, groenten, fruit \nen graanproducten zitten er allemaal vol mee.";
        answerInfo[2] = "Er zitten best veel calorieën in 1 portie.\n Zelfs als ze de McChicken delen krijgen \nze allebei nog steeds 225 calorieën binnen.";

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

    public GameObject scoreObject;

    //readonly int DEFAULT_SCORE = 0;
    readonly int POINT = 1;
    int scoreCount;

    public void ClickAnswerButton(int knopId)
	{
		// Correct / Incorrect answer must be done here
		// Score can be done here as well

		//The answer button that the user clicked changes color to yellow
		AnswerButtons[knopId].GetComponent<Image>().color = Color.yellow;
        //Looks if the right or wrong answer is clicked
        if (AnswerButtons[knopId] == AnswerButtons[QuestionAmount])
        {
            scoreCount += POINT;
        }
        
        scoreObject.GetComponent<Text>().text = scoreCount.ToString();
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
		AnswerButtons[QuestionAmount].GetComponent<Image>().color = Color.green;
        //Shows the correct answerr

		QuestionText.GetComponent<Text>().text = "Het goede antwoord was:\n\n" + Answers[QuestionAmount]
            + "\n" + answerInfo[QuestionAmount];

		StartCoroutine(NextCorrectAnswer());
	}

	IEnumerator NextCorrectAnswer()
	{
		yield return new WaitForSeconds(2);
        
        StartCoroutine(ShowScoreboard());
    }

    IEnumerator ShowScoreboard()
    {
        AnswerScreen.SetActive(false);
        //GameScreen.SetActive(false);
		QuestionText.GetComponent<Text>().text = "";
        ScoreScreen.SetActive(true);

        yield return new WaitForSeconds(2);

        if (QuestionAmount >= TotalQuestionAmount)
        {
            gameStateScript.ScoreScreen.SetActive(false);
            gameStateScript.EndScreen.SetActive(true);
        } else {
            // Temporary test switch
            ScoreScreen.SetActive(false);
            GameScreen.SetActive(true);
            UserInputScreen.SetActive(true);
            ShowQuestion();
        }
    }

    void ShowQuestion() {
        QuestionText.GetComponent<Text>().text = questionArray[QuestionAmount];
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
