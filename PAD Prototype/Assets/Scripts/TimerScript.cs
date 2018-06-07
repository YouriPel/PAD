using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public GameObject timer;
    //Speed in seconds
    public float speed;
    //Size of the timer
    private Vector2 size;

    //Colors for the timer
    public Color colorGreen;
    public Color colorRed;

    //Determines the smoothness of the lerp. Smaller values are smoother.
    float smoothness = 0.02f;
    //This float will serve as the 3rd parameter of the lerp function
    float progress = 0; 

    void Start ()
    {
        StartCoroutine("ChangeColor");
    }

    IEnumerator ChangeColor()
    {
        while(progress < 1)
        {
            GetComponent<RawImage>().color = Color.Lerp(colorGreen, colorRed, progress);
            progress += (smoothness / (speed / 2)); //The amount of change to apply
            yield return new WaitForSeconds(smoothness);
        }
    }

	void Update ()
    {
        ChangeSize();
    }

    void ChangeSize()
    {
        size = transform.localScale;

        //Changes y size 
        size.y -= Time.deltaTime * (speed / 100);

        //If size is above 0, continue changing y size
        if (size.y > 0)
        {
            transform.localScale = size;
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
}
