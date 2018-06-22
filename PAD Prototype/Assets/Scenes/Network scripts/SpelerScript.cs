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
		this.transform.SetParent (GameObject.Find("Canvas").transform);
        this.GetComponent<RectTransform>().localScale = new Vector2(1,1);
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManagerScript>();

    }

	void Update(){
		if (!isLocalPlayer)
			return;
	}

    public void SendAnswer()
    {
		print ("klik: "+playerInput.text);
		CmdSetAnswer(playerInput.text);
    }

	[Command]
	void CmdSetAnswer(String input){
		gameManager.antwoordText = input;
	}

    
}
