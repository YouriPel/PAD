using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transitionEffectScript : MonoBehaviour {

	public bool left;

	RectTransform rectComponent;

	void Start(){
		rectComponent = this.GetComponent<RectTransform> ();
	}

	bool move;
	void Update(){
		if(move){
			
		}	
	}
}
