﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour {

    public List<String> userScores;

    public GameObject username1;
    public GameObject username2;
    public GameObject username3;
    public GameObject username4;

    public InputField username;

    public int score;
    public String name;

    private readonly int CORRECT_ANSWER_POINT = 1;
    private readonly int RESET_SCORE = 0;

    public void Start() {
        this.SetName(username.GetComponent<Text>().text);
        this.ResetScore();
    }

    public void AddScore() {
        score += CORRECT_ANSWER_POINT;
    }

    public void ResetScore() {
        score = RESET_SCORE;
    }

    public void SetName(String name) {
        this.name = name;
    }

    public String GetName() {
        return name;
    }

    public int GetScore() {
        return score;
    }

    public void SetScoreboard() {
        // TODO: Set if statements for user amount (Network related)
        userScores = new List<String> { username1.GetComponentInChildren<Text>().GetComponent<Text>().text, username2.GetComponentInChildren<Text>().GetComponent<Text>().text,
                                        username3.GetComponentInChildren<Text>().GetComponent<Text>().text, username4.GetComponentInChildren<Text>().GetComponent<Text>().text };
        // TODO: Sort on score
        userScores.Sort();
    }
}