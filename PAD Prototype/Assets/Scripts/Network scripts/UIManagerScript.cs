using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerScript : MonoBehaviour {

	private GameObject vraagObject, inputObject;
	void Start () {
		vraagObject = GameObject.Find ("Vraag");
		inputObject = GameObject.Find ("PlayerInput");

		vraagObject.SetActive (true);
		inputObject.SetActive (true);
	}
}
