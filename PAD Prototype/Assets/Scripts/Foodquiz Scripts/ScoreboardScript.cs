using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScoreboardScript : MonoBehaviour {

    // Initialize script
    public Player playerScript;

    // Initialize variables
    public Dictionary<string, int> playerScore = new Dictionary<string, int>();
    public List<Player> players = new List<Player>();
    public Text[] nameText = new Text[4];
    public Text[] scoreText = new Text[4];
    public Text factsText;
    private int factCounter = 0;
    public int playerId = 0;
    public int counter = 0;

    // Initialize readonly values
    private readonly int EQUALISE_VALUE = 1;
    private readonly int RESET_COUNTER = 0;

    //Initialize questionScript
    public QuestionScript questionScript;
    
    /// <summary>
    /// Gets the scores by name and sorts them
    /// </summary> 
    public void SetScoreboard() {
        //Set fact related to current question
        factsText.text = questionScript.facts[factCounter];
        factCounter++;

        // Get the score of each player
        for (int i = 0; i < this.GetPlayerAmount(); i++) {
            playerScore[players[i].GetName()] = players[i].GetScore();
        }

        // Sort the list based on scores
        List<KeyValuePair<string, int>> compareScoreList = playerScore.ToList();
        compareScoreList.Sort(delegate (KeyValuePair<string, int> pairOne, KeyValuePair<string, int> pairTwo) {
            return pairTwo.Value.CompareTo(pairOne.Value);
        });

        // Set the Text objects with the names and scores
        foreach (KeyValuePair<string, int> player in compareScoreList) {
            nameText[counter].text = player.Key.ToString();
            scoreText[counter].text = player.Value.ToString();
            counter++;
        }

        // Set the counter to 0
        counter = RESET_COUNTER;
    }

    /// <summary>
    /// Create a player and add it to List<Player> players
    /// </summary>
    /// <param name="name">
    /// The name of the Player
    /// </param>
    public void AddPlayer(string name) {
        playerId++;
        players.Add(playerScript.AddPlayer(name, playerId));
        playerScore.Add(name, playerScript.GetScore());
    }

    /// <summary>
    /// Get a player by it's player ID
    /// </summary>
    /// <param name="playerId">
    /// The ID of the player
    /// </param>
    /// <returns>
    /// A list of players
    /// </returns>
    public Player GetPlayer(int playerId) {
        for (int i = 0; i < this.GetPlayerAmount() + EQUALISE_VALUE; i++) {
            if (players[i].GetPlayerId() == playerId) {
                return players[i];
            }
        }
        return null;
    }

    public int GetPlayerAmount() {
        return players.Count();
    }
}
