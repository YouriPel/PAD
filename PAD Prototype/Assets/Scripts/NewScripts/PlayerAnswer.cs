using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnswer : MonoBehaviour {

    public GameObject gameStateManager;

    public void ClickAnswerButton(GameObject PlayerAnswerButton) {
        if (PlayerAnswerButton = gameStateManager.GetComponent<AnswerButton>().GetCorrectAnswerButton()) {
            gameStateManager.GetComponent<Scoreboard>().AddScore();
        }
    }
}
