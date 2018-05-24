﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GameNetworkManager : NetworkManager {

	// Use this for initialization
	private string ip;
	bool isHosting;

	void Awake () {
		Time.timeScale = 1f;
		DontDestroyOnLoad (this.gameObject);

		NetworkManager.singleton = this;
	}


	public override void OnClientConnect(NetworkConnection connection){
		print (connection.connectionId + " connected");
	}


	//================ HOST AND JOIN BUTTON METHODS ==================\\
	public void StartupHost(){
		SetPort ();
		ip = Network.player.ipAddress;
		NetworkManager.singleton.StartHost ();
		isHosting = true;
	}

	public void JoinGame(){
		if (isHosting) {
			SetIPAdress ();
			SetPort ();
			NetworkManager.singleton.StartClient ();
		} else {
			print ("PLACEHOLDER TEKST:: ER IS GEEN GAME GEHOST!");
		}
	}

	void SetPort(){
		NetworkManager.singleton.networkPort = 7777;
	}

	void SetIPAdress (){
		NetworkManager.singleton.networkAddress = ip;
	}
		
	public void StopGameHost(){
		NetworkManager.singleton.StopHost ();
		isHosting = false;
	}

	//============================ SCENE MANAGEMENT CODE==========================\\

	void OnEnable(){
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode){
		switch (scene.buildIndex) {
			case 0:
			{
				print ("menu loaded");
				break;
			}
			case 1:
			{
				print ("foodquiz loaded");
				SetupLobbyButtons ();
				break;
			}
		}
	}


	///============================ ADDING LISTENERS TO HOST AND JOIN BUTTON ==========================\\
	void SetupLobbyButtons(){
		//removelistener is om de list te refreshen als het spel opnieuw gespeeld word
		//Anders heb je een listener met geen script erin, dus krijg je errors
		GameObject.Find ("HostButton").GetComponent<Button> ().onClick.RemoveAllListeners ();
		GameObject.Find ("HostButton").GetComponent<Button> ().onClick.AddListener (StartupHost);

		GameObject.Find ("JoinButton").GetComponent<Button> ().onClick.RemoveAllListeners ();
		GameObject.Find ("JoinButton").GetComponent<Button> ().onClick.AddListener (JoinGame);

		//GameObject.Find ("TerugButton").GetComponent<Button> ().onClick.AddListener (StopGameHost);
	}
	/*
	void SetupOtherSceneButton(){
		GameObject.Find ("EndGameButton").GetComponent<Button> ().onClick.RemoveAllListeners ();
		GameObject.Find ("EndGameButton").GetComponent<Button> ().onClick.AddListener (StopHost);
	}*/
}