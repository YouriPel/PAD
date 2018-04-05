using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine;
using System;

public class SpelerScript : NetworkBehaviour
{
    public InputField playerInput;
    private String playerAnswer;
    [SyncVar(hook = "OnChangeText")]
    public String antwoordText = "";
    private GameObject antwoordObj;





    // Use this for initialization
    void Start ()
    {
        this.transform.parent = GameObject.Find("Canvas").transform;
        this.GetComponent<RectTransform>().localScale = new Vector2(1,1);
        antwoordObj = GameObject.Find("AntwoordText");

    }

    public void SendAnswer()
    {
        //knop functie
        playerAnswer = playerInput.text;
    }

    void OnChangeText(String playerAnswer)
    {
        //antwoordText = playerAnswer;
        antwoordObj.GetComponent<Text>().text = playerAnswer;
    }
}
