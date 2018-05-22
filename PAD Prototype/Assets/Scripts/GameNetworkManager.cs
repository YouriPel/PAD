using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GameNetworkManager : NetworkManager {

	// Use this for initialization
	private string ip;

	void Awake () {
		Time.timeScale = 1f;
		DontDestroyOnLoad (this.gameObject);

		NetworkManager.singleton = this;
	}

	public void StartupHost(){
		SetPort ();
		ip = Network.player.ipAddress;
		NetworkManager.singleton.StartHost ();
	}

	public void JoinGame(){
		SetIPAdress ();
		SetPort ();
		NetworkManager.singleton.StartClient ();
	}

	void SetPort(){
		NetworkManager.singleton.networkPort = 7777;
	}

	void SetIPAdress (){
		NetworkManager.singleton.networkAddress = ip;
	}

	public override void OnClientConnect(NetworkConnection connection){
		print (connection.connectionId + " connected");
	}

	//============================ SCENE MANAGEMENT CODE==========================\\

	void OnEnable(){
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode){
		if (scene.buildIndex == 0) {
			print ("menu loaded");
			//SetupMenuSceneButton ();
		}

		if (scene.buildIndex == 1) {
			print ("foodquiz loaded");
			SetupLobbyButtons ();
		}
	}


	///============================ ADDING LISTENERS TO HOST AND JOIN BUTTON ==========================\\
	void SetupLobbyButtons(){
		GameObject.Find ("HostButton").GetComponent<Button> ().onClick.RemoveAllListeners ();
		GameObject.Find ("HostButton").GetComponent<Button> ().onClick.AddListener (StartupHost);

		GameObject.Find ("JoinButton").GetComponent<Button> ().onClick.RemoveAllListeners ();
		GameObject.Find ("JoinButton").GetComponent<Button> ().onClick.AddListener (JoinGame);
	}
	/*
	void SetupOtherSceneButton(){
		GameObject.Find ("EndGameButton").GetComponent<Button> ().onClick.RemoveAllListeners ();
		GameObject.Find ("EndGameButton").GetComponent<Button> ().onClick.AddListener (NetworkManager.singleton.StopHost);
	}*/
}
