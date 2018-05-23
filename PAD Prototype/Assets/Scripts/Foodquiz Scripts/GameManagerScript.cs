using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine;
using System;

//game management stuff here
public class GameManagerScript : MonoBehaviour {

    public List<string> names;

    public GameObject playerCounterObj;
    private Text pcText;
    
    //[SyncVar(hook = "OnCounterChange")]
    public int playerCounter;

	void Start(){
        pcText = playerCounterObj.GetComponent<Text>();

    }	

    void OnCounterChange(int count)
    {
        pcText.text = ""+count;
    }
}
