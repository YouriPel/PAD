using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour {

    public GameObject gameStateManager; 

    private GameObject correctAnswerButton;
    private GameObject customAnswerButton;

    private readonly int TOTAL_ANSWER_BUTTONS = 5;

    private int randomAnswerButtonNumber;
    private List<int> randomAnswerNumber;

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

<<<<<<< HEAD
    //public GameObject[] GetAnswerButtons() {
    //    return answerButtons;
    //}
    //
    //public void SetAnswerButton(InputField playerInput) {
    //   answerButtons[this.GetRandomAnswerButton()].GetComponentInChildren<Text>().text = playerInput.text;
    //}
    //
    //private void SetCorrectAnswerButon() {
    //    correctAnswerButton.GetComponentInChildren<Text>().text = gameStateManager.GetComponent<Question>().GetCorrectAnswer();
    //    answerButtons[this.GetRandomAnswerButton()] = correctAnswerButton;
    //}
=======
    /*public GameObject[] GetAnswerButtons() {
        //return answerButtons;
    }*/

    public void SetAnswerButton(InputField playerInput) {
       //answerButtons[this.GetRandomAnswerButton()].GetComponentInChildren<Text>().text = playerInput.text;
    }

    /*private void SetCorrectAnswerButon() {
        correctAnswerButton.GetComponentInChildren<Text>().text = gameStateManager.GetComponent<Question>().GetCorrectAnswer();
       // answerButtons[this.GetRandomAnswerButton()] = correctAnswerButton;
    }*/
>>>>>>> 2ffe60c4ce7686dc84f3f8c4db00cbf1917fba05

    // Gets a random unique number 
    private int GetRandomAnswerButton() {
        System.Random randomNumber = new System.Random();
        do {
            randomAnswerButtonNumber = randomNumber.Next(TOTAL_ANSWER_BUTTONS);
        } while (randomAnswerNumber.Contains(randomAnswerButtonNumber));
        randomAnswerNumber.Add(randomAnswerButtonNumber);
        return randomAnswerButtonNumber;
    }
}
