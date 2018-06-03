using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Networking;

public class WaitScreenScript : NetworkBehaviour{

	private GameObject GameManagerObj;
	private GameManagerScript GMScript;


	public GameObject[] playerNames = new GameObject[4];

	void Awake(){
		//GameManagerObj = FindObjectOfType<GameManagerScript>();
        GMScript = FindObjectOfType<GameManagerScript>();
        //GMScript.gameObject.SetActive(true);

    }

	void Start(){

		//playerNames [0].GetComponent<Text>().text = GMScript.name;
	}

    
	void Update(){
		for (int i = 0; i < GMScript.names.Count; i++) {
			Text playerName = playerNames [i].GetComponent<Text> ();
			playerName.text = GMScript.names[i];
		}
	}

}
