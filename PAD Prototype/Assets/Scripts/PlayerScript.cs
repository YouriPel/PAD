using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class PlayerScript : NetworkBehaviour {

	public InputField playerInput;
	public Button confirmButton;

	private GameObject gameManager;
	private GameScript gameScript;

	void Start(){
		gameManager = GameObject.Find ("GameManager");
		gameScript = gameManager.GetComponent<GameScript> ();
	}

	void Update () {
		if (!isLocalPlayer)
			return;
	}

	public void SubmitAnswer(){
		gameScript.antwoorden.Add (playerInput.text);
	}
}
