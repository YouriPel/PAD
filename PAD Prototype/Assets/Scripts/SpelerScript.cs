using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine;
using System;

public class SpelerScript : NetworkBehaviour
{
    public InputField playerInput;
	public Button sendButton;
	//public Text objName;
	//private GameManagerScript gameManager;

    void Start ()
	{
		this.GetComponent<RectTransform> ().localScale = new Vector2 (1, 1);
		
		sendButton.onClick.AddListener(SendAnswer);
    }

	void Update(){
		if (!isLocalPlayer)
			return;
	}

	public void SendAnswer()
	{
		if (isLocalPlayer) {
			print ("local player");
		}
		//this.gameObject.transform.parent.GetComponent<PlayerObjectScript> ().CmdSetAnswer (playerInput.text);
		Debug.Log ("tekst: "+playerInput.text);
	}

    
}
