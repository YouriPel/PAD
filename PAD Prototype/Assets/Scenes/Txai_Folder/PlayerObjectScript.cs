using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
public class PlayerObjectScript : NetworkBehaviour {

	public GameObject playerPrefab, MyObject;
	private GameManagerScript gameManager;
	// Use this for initialization
	void Start () {
		if (!isLocalPlayer)
			return;
		
		this.transform.SetParent (GameObject.Find ("Canvas").transform);
		this.transform.localScale = new Vector2 (1, 1);
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManagerScript> ();

		ClientScene.RegisterPrefab (playerPrefab);

		//CmdSetObject ();
		CmdSetObject ();

		//ASSIGN SendAnswer() METHOD TO BUTTON CLICK

		Debug.Log ("INITIALIZE MY OWN PLAYER");
	}
	
	// Update is called once per frame
	void Update () {

		if (!hasAuthority)
			return;
	}

	[Command]
	void CmdSetObject(){
		GameObject go = Instantiate (playerPrefab);
		go.transform.SetParent (this.gameObject.transform);

		MyObject = go;
		//MyObject.GetComponent<SpelerScript> ().sendButton.onClick.AddListener(SendAnswer);
		NetworkServer.SpawnWithClientAuthority (go, connectionToClient);
		//ClientScene.RegisterPrefab (go);

		//Debug.Log ("CmdSetObject: "+MyObject);
	}

	[Command]
	public void CmdSetAnswer(String input){
		gameManager.antwoordText = input;
		Debug.Log ("CmdSetAnswer: "+input);
	}
}
