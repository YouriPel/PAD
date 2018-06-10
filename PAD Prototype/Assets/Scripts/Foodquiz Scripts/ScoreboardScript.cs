using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScoreboardScript : MonoBehaviour {

    public Player playerScript;
    public Dictionary<string, int> playerScore = new Dictionary<string, int>();
    public List<Player> players = new List<Player>();
    // public GameObject[] scoreText = new GameObject[4];
    public Text[] nameText = new Text[4];
    public Text[] scoreText = new Text[4];
    public int playerId = 0;
    public int counter = 0;

    private readonly int EQUALISE_VALUE = 1;
    private readonly int RESET_COUNTER = 0;

    public void SetScoreboard() {
        for (int i = 0; i < this.GetPlayerAmount(); i++) {
            playerScore[players[i].GetName()] = players[i].GetScore();
        }
        List<KeyValuePair<string, int>> compareScoreList = playerScore.ToList();
        compareScoreList.Sort(delegate (KeyValuePair<string, int> pairOne, KeyValuePair<string, int> pairTwo) {
            return pairTwo.Value.CompareTo(pairOne.Value);
        });

        foreach (KeyValuePair<string, int> player in compareScoreList) {
            nameText[counter].text = player.Key.ToString();
            scoreText[counter].text = player.Value.ToString();
            counter++;
        }

        counter = RESET_COUNTER;

        /*foreach (KeyValuePair<string, int> player in playerScore) {
            nameText[counter].text = player.Value.ToString();
            scoreText[counter].text = player.Key.ToString();
            counter++;
        }

        for (int i = 0; i < this.GetPlayerAmount(); i++) {
            scoreText[i].GetComponentInChildren<Text>().text = compareScoreList[i].ToString();
        }*/
    }

    public void AddPlayer(string name) {
        playerId++;
        players.Add(playerScript.AddPlayer(name, playerId));
        playerScore.Add(name, playerScript.GetScore());
    }

    public Player GetPlayer(int playerId) {
        for (int i = 0; i < this.GetPlayerAmount() + EQUALISE_VALUE; i++) {
            Debug.Log("Speler ID: " + players[i].GetPlayerId());
            Debug.Log("Meegegeven ID: " + playerId);
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
