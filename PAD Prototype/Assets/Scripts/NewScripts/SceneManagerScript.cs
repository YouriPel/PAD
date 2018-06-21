using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour {
    
	void Start() {
		DontDestroyOnLoad (this.gameObject);
	}

    void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        switch (scene.buildIndex) {
            case 0: {
                break;
            }
            case 1: {
                break;
            }
        }
    }
}
