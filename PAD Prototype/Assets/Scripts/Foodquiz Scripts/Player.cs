using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public string name;
    public int score;
    public int playerId;

    private readonly int PLAYER_AMOUNT = 4;
    private readonly int SCORE_POINT = 1;
    private readonly int DEFAULT_SCORE = 0;

    public Player(string name, int playerId) {
        this.playerId = playerId;
        Debug.Log(playerId);
        this.name = name;
        this.score = DEFAULT_SCORE;
    }

    public Player AddPlayer(string name, int playerId) {
        Player player = new Player(name, playerId);
        return player;
    }

    public string GetName() {
        return name;
    }

    public int GetScore() {
        return score;
    }

    public void UpdateScore() {
        this.score += SCORE_POINT;
    }

    public void ResetScore() {
        this.score = 0;
    }

    public int GetPlayerId() {
        return playerId;
    }
}