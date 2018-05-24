using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class WaitScreenScript : MonoBehaviour {

	private GameObject GameManagerObj;
	private GameManagerScript GMScript;


	public GameObject[] playerNames = new GameObject[4];

	void Awake(){
		GameManagerObj = GameObject.Find ("GameManager");
		GMScript = GameManagerObj.GetComponent<GameManagerScript> ();
	}

    /*
	void Update(){
		for (int i = 0; i < GMScript.names.Count; i++) {
			Text playerName = playerNames [i].GetComponent<Text> ();
			playerName.text = GMScript.names[i];
		}
	}*/

}
