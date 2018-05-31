using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour {
    
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.buildIndex)
        {
            case 0:
                {
                    //print("menu loaded");
                    break;
                }
            case 1:
                {
                    // print("foodquiz loaded");
                    this.transform.parent.GetComponent<GameGodScript>().activateObj = true;
                    GameObject.Find("NetworkManager").GetComponent<GameNetworkManager>().SetupLobbyButtons();
                    break;
                }
        }
    }
}
