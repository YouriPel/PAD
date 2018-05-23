using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGodScript : MonoBehaviour {
    
	void Awake () {
        DontDestroyOnLoad(this.gameObject);
    }

}
