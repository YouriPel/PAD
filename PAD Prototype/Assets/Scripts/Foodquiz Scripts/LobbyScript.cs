using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LobbyScript : MonoBehaviour {

	public InputField nameInput;
	public Text spelerText;
	private GameObject gameStateObj;
	private GameManagerScript gameManagerScript;
	private GameStateScript gameStateScript;
	private int playerCount;

    void Awake(){
		gameStateObj = GameObject.Find("GameManager");
		gameManagerScript = gameStateObj.GetComponent<GameManagerScript> ();
		gameStateScript = gameStateObj.GetComponent<GameStateScript> ();

    }

	void Start(){
		ChangeSpelerText (1);
	}

	void ChangeSpelerText(int huidigeSpeler){
		int huidigeSpelerCount = playerCount + huidigeSpeler;
		spelerText.text = "Speler "+huidigeSpelerCount;
	}

	public void InsertPlayerName(InputField playerInput){
		gameManagerScript.playerNamen [playerCount] = playerInput.text;

		if(playerCount  == 3){
			this.gameObject.SetActive (false);
			gameStateScript.playButton ();

		}else{
			playerCount++;
			ChangeSpelerText (1);
		}
	}
}
