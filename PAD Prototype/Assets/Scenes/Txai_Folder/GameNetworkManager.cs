using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GameNetworkManager : NetworkManager {

	private GameManagerScript gameManager;
	// Use this for initialization
	string ip;
	int port; 
	void Awake () {
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManagerScript> ();
		Time.timeScale = 1f;
	}

	public override void OnServerConnect(NetworkConnection connection){
		print (connection.connectionId+" server Connected!");
	}

	public override void OnClientConnect(NetworkConnection connection){
		print (connection.connectionId+" Connected!");
		if(Network.connections.Length == 0){
			ip = Network.player.ipAddress;
			port = Network.player.port;
		}
		else{
			Network.Connect (ip, port);
		}

		print ("IP: "+ip +" port: "+port);
	}

	public override void OnStartHost(){
		print ("host start");
	}

	public override void OnStartServer(){
		print ("server start");
	}
}
