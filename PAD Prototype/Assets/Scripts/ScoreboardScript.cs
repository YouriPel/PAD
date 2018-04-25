using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreboardScript : MonoBehaviour {
    //Make GameObject user
    public GameObject scoreObject;
    //readonly int DEFAULT_SCORE = 0;
    readonly int POINT = 1;
    int scoreCount;

    // Use this for initialization
    void Start () {
        SetScoreboard();
        scoreCount = 0;

    }
	
    public void SetScoreboard()
    {
        GameScreenScript game = new GameScreenScript();
        
        if (game.goedFout)
        {
            scoreCount += POINT;
        }
        scoreObject.GetComponent<Text>().text = scoreCount.ToString();
    }

	// Update is called once per frame
	void Update () {
        SetScoreboard();
    }
}
