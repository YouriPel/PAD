using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LobbyScript : MonoBehaviour
{
	public InputField nameInput;
    public Text nameText;
    public Text spelerText;
    public Text speler1Text;
    public Text speler2Text;
    public Text speler3Text;
    public Text speler4Text;
    private GameObject gameStateObj;
	private GameManagerScript gameManagerScript;
	private GameStateScript gameStateScript;
    private Player playerScript;
    public ScoreboardScript scoreboardScript;
	private int playerCount;

    void Awake()
    {
		gameStateObj = GameObject.Find("GameManager");
		gameManagerScript = gameStateObj.GetComponent<GameManagerScript> ();
		gameStateScript = gameStateObj.GetComponent<GameStateScript> ();
    }

	void Start()
    {
		ChangeSpelerText (1);
	}

	void ChangeSpelerText(int huidigeSpeler)
    {
		int huidigeSpelerCount = playerCount + huidigeSpeler;
		spelerText.text = "Speler " + huidigeSpelerCount;
	}

	public void InsertPlayerName(InputField playerInput)
    {
        if(playerCount < 4)
        {
            if(playerInput.text != "")
            {
                scoreboardScript.AddPlayer(playerInput.text);
            }
        }

		if(playerCount == 4)
        {
			this.gameObject.SetActive (false);
			gameStateScript.playButton ();
		}
        else
        {
			playerCount++;
			ChangeSpelerText (1);

            switch(playerCount)
            {
                case 1:
                    speler1Text.text = "Speler 1: " + playerInput.text;
                    break;
                case 2:
                    speler2Text.text = "Speler 2: " + playerInput.text;
                    break;
                case 3:
                    speler3Text.text = "Speler 3: " + playerInput.text;
                    break;
                case 4:
                    speler4Text.text = "Speler 4: " + playerInput.text;
                    nameInput.gameObject.SetActive(false);
                    nameText.gameObject.SetActive(false);
                    spelerText.text = "Dit zijn de spelers.";
                    break;
                default:
                    break;
            }
            playerInput.text = "";
        }
	}
}
