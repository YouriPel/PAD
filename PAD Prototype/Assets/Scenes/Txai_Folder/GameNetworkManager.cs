using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GameNetworkManager : NetworkManager {

	// Use this for initialization
	void Start () {
		
	}
	
	public override void OnClientConnect(NetworkConnection connection){
		print (connection.connectionId+" Connected!");
		//GameObject go = Instantiate (playerPrefab);
		//go.transform.SetParent (GameObject.Find ("Canvas").transform);
	}
}
