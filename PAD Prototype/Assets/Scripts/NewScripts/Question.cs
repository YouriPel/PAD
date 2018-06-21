using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour {

    private String question;
    private String correctAnswer;
    private int randomQuestionNumber;
    private List<int> totalQuestions;

    private readonly int MAXIMUM_QUESTION_AMOUNT = 3;

    public String GetQuestion() {
        return question;
    }

    public String GetCorrectAnswer() {
        return correctAnswer;
    }

    // Gets a random unique number 
    private int GetRandomQuestionNumber() {
        System.Random randomNumber = new System.Random();
        do {
            randomQuestionNumber = randomNumber.Next(MAXIMUM_QUESTION_AMOUNT);
        } while (totalQuestions.Contains(randomQuestionNumber));
        totalQuestions.Add(randomQuestionNumber);
        return randomQuestionNumber;
    }
}
