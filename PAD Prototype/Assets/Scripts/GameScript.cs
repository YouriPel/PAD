using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameScript : NetworkBehaviour {

	public List<string> antwoorden = new List <string>();

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(antwoorden.Count > 0){
			for(int i=0; i<antwoorden.Count; i++){
				print ("antwoord: "+antwoorden[i]);
			}
		}

	}
}
