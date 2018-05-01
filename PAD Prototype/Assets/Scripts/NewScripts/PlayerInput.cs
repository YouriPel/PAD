using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour {
    
    private String playerInput;

    public void SetPlayerInput(InputField inputField) {
        this.playerInput = inputField.text;
    }
	
    public String GetPlayerInput() {
        return playerInput;
    }
}
