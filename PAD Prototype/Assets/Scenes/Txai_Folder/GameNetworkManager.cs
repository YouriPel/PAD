using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GameNetworkManager : NetworkManager {

	private GameManagerScript gameManager;
	// Use this for initialization
	void Awake () {
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManagerScript> ();
		Time.timeScale = 1f;
	}
	
	public override void OnClientConnect(NetworkConnection connection){
		print (connection.connectionId+" Connected!");
		gameManager.count++;
		print ("gameManager.count: "+gameManager.count);
		//GameObject go = Instantiate (playerPrefab);
		//go.transform.SetParent (GameObject.Find ("Canvas").transform);
	}
}
