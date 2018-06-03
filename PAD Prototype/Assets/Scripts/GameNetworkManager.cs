using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GameNetworkManager : NetworkManager {
    
	private string ip;

	void Awake () {
		Time.timeScale = 1f;
        ip = "127.0.0.1";

        NetworkManager.singleton = this;
	}

    /*void Update()
    {
        if (this.transform.parent.GetComponent<GameGodScript>().activateObj)
        {
            NetworkServer.Spawn(GameObject.Find("GameManager"));
        }
    }*/

    public override void OnClientConnect(NetworkConnection connection){
		print (connection.connectionId + " connected");
        ClientScene.Ready(connection);
        ClientScene.AddPlayer(0);
    }

	public override void OnClientDisconnect(NetworkConnection connection){
		print (connection.connectionId + " disconnected");
	}


	//================ HOST AND JOIN BUTTON METHODS ==================\\
	public void StartupHost(){
		SetPort ();
		//ip = Network.player.ipAddress;
		NetworkManager.singleton.StartHost ();
        GameObject.Find ("TerugButton").GetComponent<Button> ().onClick.RemoveAllListeners ();
		GameObject.Find ("TerugButton").GetComponent<Button> ().onClick.AddListener (StopGameHost);
		print ("HOST ip: "+ip);
	}

	public void JoinGame(){
		SetIPAdress ();
		SetPort ();
		NetworkManager.singleton.StartClient ();
        Debug.Log("isNetworkActive: " + isNetworkActive);
        print("CLIENT ip: " + ip);

        NetworkServer.Spawn(GameObject.Find("GameManager"));
    }

	void SetPort(){
		NetworkManager.singleton.networkPort = 7777;
	}

	void SetIPAdress (){
		NetworkManager.singleton.networkAddress = ip;
	}
		
	public void StopGameHost(){
		NetworkManager.singleton.StopHost ();
		print ("stopgamehost");
	}

    ///============================ ADDING LISTENERS TO HOST AND JOIN BUTTON ==========================\\
    public void SetupLobbyButtons(){
		//removelistener is om de list te refreshen als het spel opnieuw gespeeld word
		//Anders heb je een listener met geen script erin, dus krijg je errors
		GameObject.Find ("HostButton").GetComponent<Button> ().onClick.RemoveAllListeners ();
		GameObject.Find ("HostButton").GetComponent<Button> ().onClick.AddListener (StartupHost);

		GameObject.Find ("JoinButton").GetComponent<Button> ().onClick.RemoveAllListeners ();
		GameObject.Find ("JoinButton").GetComponent<Button> ().onClick.AddListener (JoinGame);

	}
	/*
	void SetupOtherSceneButton(){
		GameObject.Find ("EndGameButton").GetComponent<Button> ().onClick.RemoveAllListeners ();
		GameObject.Find ("EndGameButton").GetComponent<Button> ().onClick.AddListener (StopHost);
	}*/
}
