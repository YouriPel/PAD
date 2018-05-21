using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
public class PlayerObjectScript : NetworkBehaviour {

	public GameObject playerPrefab, go, MyObject;
	private GameManagerScript gameManager;
	// Use this for initialization
	void Start () {
		if (!isLocalPlayer)
			return;

		gameManager = GameObject.Find ("GameManager").GetComponent<GameManagerScript> ();

		go = Instantiate (playerPrefab) as GameObject;
		CmdSetObject ();

		Debug.Log ("INITIALIZE MY OWN PLAYER");
	}
	
	// Update is called once per frame
	void Update () {

		if (!isLocalPlayer)
			return;
	}

	[Command]
	void CmdSetObject(){
		if(isLocalPlayer){
			MyObject = go;
			NetworkServer.Spawn (MyObject);
			Debug.Log ("SET MYOBJECT");
		}
	}

	public void SendAnswer()
	{
		CmdSetAnswer(MyObject.GetComponent<SpelerScript> ().playerInput.text);
		Debug.Log ("tekst: "+MyObject.GetComponent<SpelerScript> ().playerInput.text);
	}
	[Command]
	public void CmdSetAnswer(String input){
		gameManager.antwoordText = input;
	}
}
