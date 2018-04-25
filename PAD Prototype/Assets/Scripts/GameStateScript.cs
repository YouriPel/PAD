using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateScript : MonoBehaviour {

	//CODE NOG NETTER, INHERITANCE??
	[Header("Gamestates")]
	public GameObject MainMenu;
	public GameObject GameScreen;
	public GameObject EndScreen;
    public GameObject AnswerScreen;
    public GameObject ScoreScreen;

	void Start () {
		MainMenu.SetActive(true);
		GameScreen.SetActive (false);
		EndScreen.SetActive (false);
        AnswerScreen.SetActive(false);
        ScoreScreen.SetActive(false);
    }

	//Method for the startbutton
	public void StartGame() {
		MainMenu.SetActive(false);
		GameScreen.SetActive(true);
	}
    
	//Method for the back to main menu button
	public void ClickEndGameButton() {
		EndScreen.SetActive(false);
		MainMenu.SetActive(true);
	}
}
