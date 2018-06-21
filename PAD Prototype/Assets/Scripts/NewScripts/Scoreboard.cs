using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour {

    public GameObject username;

    private int score;
    private String name;

    private readonly int CORRECT_ANSWER_POINT = 1;
    private readonly int RESET_SCORE = 0;

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
}
