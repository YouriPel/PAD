using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour {

    public GameObject gameStateManager; 

    private GameObject correctAnswerButton;
    private GameObject customAnswerButton;

    public void SetCustomAnswerButton(InputField playerInput) {
        customAnswerButton.GetComponentInChildren<Text>().text = playerInput.text;
    }

    private void SetCorrectAnswerButon() {
        correctAnswerButton.GetComponentInChildren<Text>().text = gameStateManager.GetComponent<Question>().GetCorrectAnswer();
    }

    private GameObject GetCustomAnswerButton() {
        return customAnswerButton;
    }

    public GameObject GetCorrectAnswerButton() {
        return correctAnswerButton;
    }

    //// TODO: Decide the total answer buttons
    //private readonly int TOTAL_ANSWER_BUTTONS = 5;

    //private int randomAnswerButtonNumber;
    //private List<int> randomAnswerNumber;

    //public GameObject[] GetAnswerButtons() {
    //    return answerButtons;
    //}

    //public void SetAnswerButton(InputField playerInput)
    //{
    //    answerButtons[this.GetRandomAnswerButton()].GetComponentInChildren<Text>().text = playerInput.text;
    //}

    //private void SetCorrectAnswerButon()
    //{
    //    correctAnswerButton.GetComponentInChildren<Text>().text = gameStateManager.GetComponent<Question>().GetCorrectAnswer();
    //    answerButtons[this.GetRandomAnswerButton()] = correctAnswerButton;
    //}

    //// Gets a random unique number 
    //// (Not sure if it works yet)
    //private int GetRandomAnswerButton() {
    //    System.Random randomNumber = new System.Random();
    //    do {
    //        randomAnswerButtonNumber = randomNumber.Next(TOTAL_ANSWER_BUTTONS);
    //    } while (randomAnswerNumber.Contains(randomAnswerButtonNumber));
    //    randomAnswerNumber.Add(randomAnswerButtonNumber);
    //    return randomAnswerButtonNumber;
    //}
}
