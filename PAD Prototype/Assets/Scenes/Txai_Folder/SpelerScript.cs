using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine;
using System;

public class SpelerScript : NetworkBehaviour
{
    public InputField playerInput;

    [SyncVar(hook = "OnChangeText")]
    public String antwoordText = "";

    private GameObject antwoordObj;


    void Start ()
    {
		this.transform.SetParent (GameObject.Find("Canvas").transform);
        this.GetComponent<RectTransform>().localScale = new Vector2(1,1);
        antwoordObj = GameObject.Find("AntwoordText");

    }

	void Update(){
		if (!isLocalPlayer)
			return;
	}

    public void SendAnswer()
    {
        //knop functie
		if(isLocalPlayer)CmdSetAnswer(playerInput.text);
    }

	[Command]
	void CmdSetAnswer(String input){
		antwoordText = input;
		print ("Input: " + input);
	}

    void OnChangeText(String answer)
    {
        print("answer: "+answer);
        //antwoordText = playerAnswer;
		antwoordObj.GetComponent<Text>().text = answer;
    }
}
