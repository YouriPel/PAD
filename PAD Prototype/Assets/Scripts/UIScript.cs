using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

    public GameObject menu;
    public GameObject gameFrame;
    public GameObject question;
    public GameObject questionFrame;
    public GameObject answerFrame;
	public GameObject GameHolder;
    public GameObject endFrame;

    void Start()
    {
        menu.SetActive(true);
        gameFrame.SetActive(false);
        question.SetActive(false);
        questionFrame.SetActive(false);
        answerFrame.SetActive(false);
        endFrame.SetActive(false);
    }

    public void KlikStartButton()
    {
        menu.SetActive(false);
        gameFrame.SetActive(true);
        question.SetActive(true);
        questionFrame.SetActive(true);
    }

    public void ClickSendAnswerButton()
    {
        questionFrame.SetActive(false);
        answerFrame.SetActive(true);
		GameHolder.GetComponent<VragenScript> ().SetAnswer ();
    }

    public void ClickAnswerButton()
    {
        answerFrame.SetActive(false);
        gameFrame.SetActive(false);
        endFrame.SetActive(true);
    }

    public void ClickEndGameButton()
    {
        endFrame.SetActive(false);
        menu.SetActive(true);
    }
}
