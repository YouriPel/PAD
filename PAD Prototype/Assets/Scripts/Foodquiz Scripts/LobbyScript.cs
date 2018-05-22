using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LobbyScript : MonoBehaviour {

	public InputField nameInput;
	private GameObject GameManagerObj;
	private GameManagerScript GMScript;

	void Awake(){
		GameManagerObj = GameObject.Find ("GameManager");
		GMScript = GameManagerObj.GetComponent<GameManagerScript> ();
	}

	public void UseNameButton(InputField nameInput){
		GMScript.names.Add (nameInput.text);
	}

}
