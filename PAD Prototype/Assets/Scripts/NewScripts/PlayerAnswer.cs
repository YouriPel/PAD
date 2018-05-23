using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnswer : MonoBehaviour {

    public GameObject gameStateManager;
    public GameObject playerAnswerButton;

    public void ClickAnswerButton(GameObject playerAnswerButton) {
        if (playerAnswerButton = gameStateManager.GetComponent<AnswerButton>().GetCorrectAnswerButton()) {
            gameStateManager.GetComponent<Scoreboard>().AddScore();
        }
        this.playerAnswerButton = playerAnswerButton;
    }

    public GameObject GetPlayerAnswerButton() {
        return playerAnswerButton;
    }
}
