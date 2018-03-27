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
	public GameObject GameManager;

    void Start()
    {
        menu.SetActive(true);
        gameFrame.SetActive(false);
        question.SetActive(false);
        questionFrame.SetActive(false);
        answerFrame.SetActive(false);
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
		GameManager.GetComponent<VragenScript> ().SetAnswer ();
    }
}
