using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour {

    // Initialize all objects
    public Text spelerText;
    public Text nameText;
    public Text speler1Text;
    public Text speler2Text;
    public Text speler3Text;
    public Text speler4Text;
    public Text scoreboardText;

    public Button volgendeButton;
    public Button endGameButton;
    public Button englishButton;
    public Button dutchButton;

    public InputField nameField;

    public AudioSource music;
    public AudioSource selectSound;
    public AudioSource backSound;
    public AudioSource correctSound;
    public AudioSource incorrectSound;

    /// <summary>
    /// Change the text of all objects to English
    /// </summary>
    public void ToggleEnglishLanguage() {
        spelerText.text = "Player x";
        nameText.text = "Enter your name";
        nameField.GetComponentInChildren<Text>().text = "Name here";
        speler1Text.text = "Player 1: ";
        speler2Text.text = "Player 2: ";
        speler3Text.text = "Player 3: ";
        speler4Text.text = "Player 4: ";
        volgendeButton.GetComponentInChildren<Text>().text = "Next";
        scoreboardText.text = "Scoreboard";
        endGameButton.GetComponentInChildren<Text>().text = "Close";

        dutchButton.enabled = true;
        englishButton.enabled = false;
    }

    /// <summary>
    /// Change the text of all objects to Dutch
    /// </summary>
    public void ToggleDutchLanguage() {
        spelerText.text = "Speler x";
        nameText.text = "Voer je naam";
        nameField.GetComponentInChildren<Text>().text = "Naam hier";
        speler1Text.text = "Speler 1: ";
        speler2Text.text = "Speler 2: ";
        speler3Text.text = "Speler 3: ";
        speler4Text.text = "Speler 4: ";
        volgendeButton.GetComponentInChildren<Text>().text = "Volgende";
        scoreboardText.text = "Scorebord";
        endGameButton.GetComponentInChildren<Text>().text = "Afsluiten";

        englishButton.enabled = true;
        dutchButton.enabled = false;
    }

    /// <summary>
    /// Toggle the in-game music
    /// </summary>
    public void ToggleMusic() {
        music.mute = !music.mute;
    }

    /// <summary>
    /// Toggle the in-game sound effects
    /// </summary>
    public void ToggleSoundeffects() {
        selectSound.mute = !selectSound.mute;
        backSound.mute = !backSound.mute;
        correctSound.mute = !correctSound.mute;
        incorrectSound.mute = !incorrectSound.mute;
    }
}
