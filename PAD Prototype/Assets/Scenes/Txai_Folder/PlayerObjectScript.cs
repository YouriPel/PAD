﻿using System.Collections;
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
		this.transform.localScale = new Vector3 (1, 1, 1);
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManagerScript> ();

		//ClientScene.RegisterPrefab (playerPrefab);

		//CmdSetObject ();

		GameObject go = Instantiate (playerPrefab);
		go.transform.SetParent (this.gameObject.transform);
		Debug.Log ("INITIALIZE MY OWN PLAYER");

	}
	
	// Update is called once per frame
	void Update () {

		if (!hasAuthority)
			return;
	}
	/*
	[Command]
	void CmdSetObject(){
		GameObject go = Instantiate (playerPrefab);
		go.transform.SetParent (this.gameObject.transform);

		MyObject = go;
		Debug.Log ("INITIALIZE MY OWN PLAYER");

		//NetworkServer.SpawnWithClientAuthority (go, connectionToClient);
	}*/

	[Command]
	public void CmdSetAnswer(String input){
		gameManager.antwoordText = input;
		Debug.Log ("CmdSetAnswer: "+input);
	}
}
