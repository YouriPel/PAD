using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine;
using System;

public class SpelerScript : NetworkBehaviour
{
    public InputField playerInput;
	//public Text objName;
	//private GameManagerScript gameManager;

    void Start ()
	{
			this.transform.SetParent (GameObject.Find ("Canvas").transform);
			this.GetComponent<RectTransform> ().localScale = new Vector2 (1, 1);
			//gameManager = GameObject.Find ("GameManager").GetComponent<GameManagerScript> ();

			//objName.text = "player " + gameManager.ID;
			//NetworkServer.AddPlayerForConnection (connectionToServer, this.gameObject, 0);
			//gameManager.ID++;

    }

	void Update(){
		//print ("isLocalPlayer: "+isLocalPlayer);
	}

   /* public void SendAnswer()
    {
		CmdSetAnswer(playerInput.text);
    }

	[Command]
	void CmdSetAnswer(String input){
		//gameManager.antwoordText = input;
	}*/

    
}
