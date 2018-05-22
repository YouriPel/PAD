using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine;
using System;

public class GameManagerScript : NetworkBehaviour {

	[SyncVar(hook = "OnChangeText")]
	public String antwoordText = "";

	[SyncVar(hook = "OnChangeCount")]
	public int count;

	private GameObject antwoordObj, countObj;

	// Use this for initialization
	void Start ()
	{
		this.gameObject.SetActive (true);
		antwoordObj = GameObject.Find("AntwoordText");
		countObj = GameObject.Find("countText");
	}

	void Update(){
		if (!isServer)
			return;
	}

	void OnChangeText(String answer)
	{
		antwoordObj.GetComponent<Text>().text = answer;
	}

	void OnChangeCount(int count){
		countObj.GetComponent<Text>().text = ""+count;
	}
}
