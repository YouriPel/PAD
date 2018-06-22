using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine;
using System;

public class SpelerScript : NetworkBehaviour
{
    public InputField playerInput;
	private GameManagerScript gameManager;

    void Start ()
    {
		this.transform.SetParent (GameObject.Find("Canvas").transform);  //Spawn playerprefab as child of Canvas
        this.GetComponent<RectTransform>().localScale = new Vector2(1,1); 
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManagerScript>(); //Find object "GameManager" and get the GameManagerScript attached as component.

    }

	void Update(){
		//If this not the local player
		if (!isLocalPlayer) 
			return;
	}

	//Method for playerButton listener
    public void SendAnswer()
    {
		//print ("klik: "+playerInput.text);
		CmdSetAnswer(playerInput.text);
    }

	//Method that is called by the NetworkManager
	[Command]
	void CmdSetAnswer(String input){
		gameManager.antwoordText = input;
	}

    
}
