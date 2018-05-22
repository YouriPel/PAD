using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public void StartClick(){
		SceneManager.LoadScene (1);
	}
}
