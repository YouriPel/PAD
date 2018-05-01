using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour {

    // TODO: Remove the Strings after the variables
    public String question = "Hallo";
    public String correctAnswer = "Goed";
    
    private int randomQuestionNumber;

    private List<int> totalQuestions;

    // TODO: Adjust to amount of questions in database
    private readonly int MAXIMUM_QUESTION_AMOUNT = 3;

    public String GetQuestion() {
        // TODO: Return has to have the SQL query with randomQuestionNumber as the variable
        return question;
    }

    public String GetCorrectAnswer() {
        // TODO: Return has to have the SQL query with randomQuestionNumber as the variable
        return correctAnswer;
    }

    // Gets a random unique number 
    // (Not sure if it works yet)
    private int GetRandomQuestionNumber() {
        System.Random randomNumber = new System.Random();
        do {
            randomQuestionNumber = randomNumber.Next(MAXIMUM_QUESTION_AMOUNT);
        } while (totalQuestions.Contains(randomQuestionNumber));
        totalQuestions.Add(randomQuestionNumber);
        return randomQuestionNumber;
    }
}
