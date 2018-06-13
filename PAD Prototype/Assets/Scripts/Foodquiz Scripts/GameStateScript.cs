using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateScript : MonoBehaviour {

    [Header("Gamestates")]
    public GameObject menuScreen;
	public GameObject LobbyScreen;
	public GameObject GameScreen;
	public GameObject EndScreen;
    public GameObject ScoreScreen;

	void Start ()
    {
        menuScreen.SetActive(true);
        LobbyScreen.SetActive(false);
		GameScreen.SetActive (false);
		EndScreen.SetActive (false);
        ScoreScreen.SetActive(false);
    }

	public void WaitForPlayersScreen(){
        LobbyScreen.SetActive(false);
	}

    public void MenuToLobbyButton()
    {
        menuScreen.SetActive(false);
        LobbyScreen.SetActive(true);
    }

    public void BackButton()
    {
        LobbyScreen.SetActive(true);
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
