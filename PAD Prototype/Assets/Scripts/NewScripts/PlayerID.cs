using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerID : MonoBehaviour {

    private int playerId;
	
    public void SetPlayerId(int playerId) {
        this.playerId = playerId;
    }

    public int GetPlayerId() {
        return playerId;
    }
}
