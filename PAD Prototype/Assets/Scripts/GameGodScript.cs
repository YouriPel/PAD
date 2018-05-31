using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGodScript : MonoBehaviour {

    public bool activateObj;

	void Awake () {
        DontDestroyOnLoad(this.gameObject);
    }

}
