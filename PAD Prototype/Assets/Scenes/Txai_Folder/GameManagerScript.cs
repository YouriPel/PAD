﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine;
using System;

public class GameManagerScript : NetworkBehaviour {

	[SyncVar(hook = "OnChangeText")]
	public String antwoordText = "";
	private GameObject antwoordObj;
	// Use this for initialization
	public int ID;
	void Start ()
	{
		this.gameObject.SetActive (true);
		antwoordObj = GameObject.Find("AntwoordText");
	}

	void Update(){
		if (!isServer)
			return;
	}

	void OnChangeText(String answer)
	{
		antwoordObj.GetComponent<Text>().text = answer;
	}
}
