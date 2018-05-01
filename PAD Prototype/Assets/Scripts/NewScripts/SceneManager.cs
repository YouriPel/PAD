using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

    // Creating the GameObjects
    public GameObject mainMenu;
    public GameObject gameScreen;
    public GameObject questionText;
    public GameObject questionAmountText;
    public GameObject userInputScreen;
    public GameObject answerScreen;
    public GameObject endGameScreen;
    public GameObject scoreScreen;

	// This acts when the game starts
	void Start () {
        ShowMenu();
	}

    public void ShowMenu() {
        mainMenu.SetActive(true);
        gameScreen.SetActive(false);
        questionText.SetActive(false);
        questionAmountText.SetActive(false);
        userInputScreen.SetActive(false);
        answerScreen.SetActive(false);
        endGameScreen.SetActive(false);
        scoreScreen.SetActive(false);
    }

    public void ShowUserInputScreen() {
        mainMenu.SetActive(false);
        gameScreen.SetActive(true);
        questionText.SetActive(true);
        questionAmountText.SetActive(true);
        userInputScreen.SetActive(true);
        answerScreen.SetActive(false);
        endGameScreen.SetActive(false);
        scoreScreen.SetActive(false);
    }

    public void ShowAnswerScreen() {
        mainMenu.SetActive(false);
        gameScreen.SetActive(true);
        questionText.SetActive(true);
        questionAmountText.SetActive(true);
        userInputScreen.SetActive(false);
        answerScreen.SetActive(true);
        endGameScreen.SetActive(false);
        scoreScreen.SetActive(false);
    }

    public void ShowScoreboard() {
        mainMenu.SetActive(false);
        gameScreen.SetActive(false);
        questionText.SetActive(false);
        questionAmountText.SetActive(false);
        userInputScreen.SetActive(false);
        answerScreen.SetActive(false);
        endGameScreen.SetActive(false);
        scoreScreen.SetActive(true);
    }

    public void ShowEndGameScreen() {
        mainMenu.SetActive(false);
        gameScreen.SetActive(false);
        questionText.SetActive(false);
        questionAmountText.SetActive(false);
        userInputScreen.SetActive(false);
        answerScreen.SetActive(false);
        endGameScreen.SetActive(true);
        scoreScreen.SetActive(false);
    }
}
