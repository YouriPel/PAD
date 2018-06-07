using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateScript : MonoBehaviour {
    
	[Header("Gamestates")]
	public GameObject Lobby;
	public GameObject GameScreen;
	public GameObject EndScreen;
    public GameObject AnswerScreen;
    public GameObject ScoreScreen;

	void Start () {
		Lobby.SetActive(true);
		GameScreen.SetActive (false);
		EndScreen.SetActive (false);
        AnswerScreen.SetActive(false);
        ScoreScreen.SetActive(false);
    }

	public void WaitForPlayersScreen(){
		Lobby.SetActive(false);
	}

    public void BackButton()
    {
        Lobby.SetActive(true);
    }

    public void playButton()
    {
        GameScreen.SetActive(true);
    }

	/*
	//Method for the back to main menu button
	public void ClickEndGameButton() {
		Application.Quit ();
	}*/
}
