using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public GameStateScript gameStateScript;
	public ScoreboardScript scoreboardScript;
	public GameScreenScript gameScreenScript;

    //Speed in seconds
    public float speed;
    //Size of the timer
    private Vector2 size;

    //Original Size of the timer
    private Vector2 orgSize = new Vector2(1, 1);

    //Colors for the timer
    public Color colorGreen;
    public Color colorRed;

    //Determines the smoothness of the lerp (color changing). Smaller values are smoother.
    float smoothness = 0.02f;
    //This float will serve as the 3rd parameter of the lerp function
    public float progress = 0;
    
    //Bool to check if the timer has started
	private bool hasStarted;

    /// <summary>
    /// Starts the timer
    /// </summary>
    public void StartTimer()
    {
		hasStarted = true;
        StartCoroutine("ChangeColor");
    }

    /// <summary>
    /// Changes the color of the timer
    /// </summary>
    IEnumerator ChangeColor()
    {
        progress = 0;//Reset progress to 0
        while (progress < 1)
        {
            //Changes the color from green to red depending on the progress
            GetComponent<RawImage>().color = Color.Lerp(colorGreen, colorRed, progress);
            progress += (smoothness / (speed / 2)); //The amount of change to apply
            yield return new WaitForSeconds(smoothness);
            
        }
        
    }

	void Update()
    {
        //If the the timer has started, start ChangeSize method
		if(hasStarted)
            ChangeSize();
    }

    /// <summary>
    /// Changes the size of the Timer
    /// </summary>
    void ChangeSize()
    {
        //Get Timer size
        size = transform.localScale;

        //Changes y size 
        size.y -= Time.deltaTime * (speed / 100);

        //If size is above 0, continue changing y size
        if (size.y > 0)
        {
            transform.localScale = size;
        }

        //If time is up, go to scoreboard
        else
        {
            ResetTimer();
            //If the bool hasChosenAnswer is false, continue to ClickAnswerButton method
            if (!gameScreenScript.hasChosenAnswer){
				gameScreenScript.ClickAnswerButton(false);
			}
        }

        #region Old code where the the color didn't change dynamicly
        ////If y size is below 75% and higher then 50%, change color to color75
        //if (size.y < 0.75 && size.y > 0.5)
        //{
        //    GetComponent<RawImage>().color = color75;
        //}
        ////If y size is below 50% and higher then 25%, change color to color50
        //else if (size.y < 0.5 && size.y > 0.25)
        //{
        //    GetComponent<RawImage>().color = color50;
        //}
        ////If y size is below 25%, change color to color25
        //else if (size.y < 0.25)
        //{
        //    GetComponent<RawImage>().color = color25;
        //}
        //else if (size.y == 0)
        //{
        //    GetComponent<RawImage>().color = color100;
        //}
        #endregion
    }

    /// <summary>
    /// Resets Timer
    /// </summary>
    public void ResetTimer()
    {
		hasStarted = false;
        //Hides Timer
		this.gameObject.SetActive (false);
        //Puts Timer back to its original size
        transform.localScale = orgSize;
        //Stop the color changing method
        StopCoroutine("ChangeColor");
        //Puts color back to green
        GetComponent<RawImage>().color = colorGreen;
    }
}
