using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine;
using System;

public class GameManagerScript : NetworkBehaviour {

	[SyncVar(hook = "OnChangeText")] //Synchronize string "antwoordText" with method "OnChangeText"
	public String antwoordText = ""; //Set as public var to view value in Inspector
	private GameObject antwoordObj;
	// Use this for initialization
	void Start ()
	{
		antwoordObj = GameObject.Find("AntwoordText"); //Find GameObject called "AntwoordText"
	}

	void Update(){
		
		if (!isServer)//Check if the current client is not the host.
			return;
	}

	void OnChangeText(String answer)
	{
		//print("answer: "+answer);
		antwoordObj.GetComponent<Text>().text = answer;
	}
}
