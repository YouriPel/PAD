using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LobbyScript : MonoBehaviour
{
	public InputField nameInput;
    public Text nameText;
	public Text startButtonText;
    public Text spelerText;
    public Text speler1Text;
    public Text speler2Text;
    public Text speler3Text;
    public Text speler4Text;
    private GameObject gameStateObj;
	private GameStateScript gameStateScript;
    private Player playerScript;
    public ScoreboardScript scoreboardScript;
    private TimerScript timerScript;
	private int playerCount;
	private String[] playerName = new string[4];



	public Image errorBorder;
	float opacity = 0, fadeSpeed = 0.01f;
	bool isFading;

    void Awake() {
		gameStateObj = GameObject.Find("GameManager");
		gameStateScript = gameStateObj.GetComponent<GameStateScript> ();
    }

	void Start() {
		ChangeSpelerText (1);
		startButtonText.text = "Volgende";
		errorBorder.color = new Color (255, 0, 0, opacity);
	}

	void Update(){
		if(isFading)ErrorBorderFade ();

        //ADDED ENTER BUTTON FOR EASY NAME INPUT ON PC.
        if (Input.GetKeyDown(KeyCode.Return)) InsertPlayerName(nameInput);

    }

	void ChangeSpelerText(int huidigeSpeler) {
		int huidigeSpelerCount = playerCount + huidigeSpeler;
		spelerText.text = "Speler " + huidigeSpelerCount;
	}

	void ErrorBorderFade(){
		if(opacity > 0){
			opacity -= fadeSpeed;
			errorBorder.color = new Color (255, 0, 0, opacity);
			print ("fading: " + opacity);
		}
		else{
			isFading = false;
			opacity = 0;
			print ("fading: klaar");
		}
		
	}

	public void ResetPlayerButton(){
		speler1Text.text = "Speler 1: ";
		speler2Text.text = "Speler 2: ";
		speler3Text.text = "Speler 3: ";
		speler4Text.text = "Speler 4: ";
		playerCount = 0;
		nameInput.gameObject.SetActive(true);
		nameText.gameObject.SetActive(true);
		ChangeSpelerText (1);
		startButtonText.text = "Volgende";
	}

	public void InsertPlayerName(InputField playerInput) {
        if(playerCount < 4) {

			if(playerInput.text == ""){
				opacity = 1;
				isFading = true;
				return;
			}
        }

		if(playerCount == 4) {
			for (int i = 0; i < playerName.Length; i++) {
				scoreboardScript.AddPlayer(playerName[i]);
			}
			this.gameObject.SetActive (false);
			gameStateScript.playButton ();

		} else {
			playerName[playerCount] = playerInput.text;
			playerCount++;
			ChangeSpelerText (1);

            switch(playerCount) {
                case 1:
                    speler1Text.text =  playerInput.text;
                    break;
                case 2:
                    speler2Text.text = playerInput.text;
                    break;
                case 3:
                    speler3Text.text = playerInput.text;
                    break;
                case 4:
                    speler4Text.text = playerInput.text;
					
                    nameInput.gameObject.SetActive(false);
                    nameText.gameObject.SetActive(false);
                    spelerText.text = "Dit zijn de spelers.";
					startButtonText.text = "Start";
                    break;
                default:
                    break;
            }
        }
        playerInput.text = "";
    }
}
