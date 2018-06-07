using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public GameObject timer;
    public float speed;
    private Vector2 size;

    //Colors for the timer
    public Color color100;
    public Color color75;
    public Color color50;
    public Color color25;

    void Start ()
    {

    }
	
	void Update ()
    {
        size = transform.localScale;
        size.y -= Time.deltaTime * speed;
        if(size.y > 0)
        {
            transform.localScale = size;
        }

        //If y size is below 75% and higher then 50%, change color to color75
        if (size.y < 0.75 && size.y > 0.5)
        {
            GetComponent<RawImage>().color = color75;
        }
        //If y size is below 50% and higher then 25%, change color to color50
        else if (size.y < 0.5 && size.y > 0.25)
        {
            GetComponent<RawImage>().color = color50;
        }
        //If y size is below 25%, change color to color25
        else if (size.y < 0.25)
        {
            GetComponent<RawImage>().color = color25;
        }
        else if (size.y == 0)
        {
            GetComponent<RawImage>().color = color100;
        }
    }
}
