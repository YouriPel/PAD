using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // Initiale attributes 
    private string name;
    private int score;
    private int playerId;

    // Initiale readonly values
    private readonly int PLAYER_AMOUNT = 4;
    private readonly int SCORE_POINT = 1;
    private readonly int DEFAULT_SCORE = 0;

    /// <summary>
    /// Create a new player
    /// </summary>
    /// <param name="name">
    /// The name of the Player
    /// </param>
    /// <param name="playerId">
    /// The ID of the player
    /// </param>
    public Player(string name, int playerId) {
        this.playerId = playerId;
        Debug.Log(playerId);
        this.name = name;
        this.score = DEFAULT_SCORE;
    }

    /// <summary>
    /// Create player from another script
    /// </summary>
    /// <param name="name">
    /// The name of the player
    /// </param>
    /// <param name="playerId">
    /// The ID of the player
    /// </param>
    /// <returns>
    /// The Player object
    /// </returns>
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

    /// <summary>
    /// Add 1 point to the score
    /// </summary>
    public void UpdateScore() {
        this.score += SCORE_POINT;
    }

    /// <summary>
    /// Set the score to 0
    /// </summary>
    public void ResetScore() {
        this.score = DEFAULT_SCORE;
    }

    public int GetPlayerId() {
        return playerId;
    }
}