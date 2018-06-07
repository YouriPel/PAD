using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScoreboardScript : MonoBehaviour {

    public GameManagerScript gameManagerScript;
    public int[] scores = new int[4];
    public Text[] names = new Text[4];
    public GameObject[] persons = new GameObject[4];
    private Text[] scores2 = new Text[4];

    public void SetScoreboard() {
        for (int i = 0; i < gameManagerScript.playerName.Length; i++) {
            scores[i] = gameManagerScript.score[i];
            scores2[i] = persons[i].transform.GetChild(1).gameObject.GetComponent<Text>();
            scores2[i].text = scores[i].ToString();
            names[i].text = gameManagerScript.playerName[i];
            persons[i].transform.GetChild(0).gameObject.GetComponent<Text>().text = names[i].text;
        }

        Array.Sort<int>(scores, new Comparison<int>((firstScore, secondScore) => secondScore.CompareTo(firstScore)));

        for (int i = 0; i < persons.Length; i++) {
            persons[i].transform.GetChild(1).gameObject.GetComponent<Text>().text = scores[i].ToString();
            persons[i].transform.GetChild(0).gameObject.GetComponent<Text>().text = names[i].text;
        }
    }
}
