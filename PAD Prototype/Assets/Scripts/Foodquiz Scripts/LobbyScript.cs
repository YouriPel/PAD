using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LobbyScript : MonoBehaviour {

	public InputField nameInput;
	private GameObject GameManagerObj;
	private GameStateScript GSScript;
    private GameManagerScript GMScript;

    void Awake(){
		GameManagerObj = GameObject.Find ("GameManager");
        GSScript = GameManagerObj.GetComponent<GameStateScript> ();
        GMScript = GameManagerObj.GetComponent<GameManagerScript>();

    }

    public void GoToWaitScreen()
    {
        GMScript.playerCounter++;
        GSScript.WaitScreen.SetActive(true);
        this.gameObject.SetActive(false);
    }
    
    
	public void UseNameButton(InputField nameInput){
		GMScript.names.Add (nameInput.text);
	}

}
