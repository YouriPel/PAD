using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScript : MonoBehaviour
{
    /*public Image logo;
    public GameObject spelNaam;
    public Button startbutton;*/

    public float scalingSpeed;
    public float opacitySpeed;
    private float scale;
    private float opacity;

    public bool scaling;
	
	// Update is called once per frame
	void Update ()
    {
        ChangeScale();
        ChangeOpacity();
		//CheckButtonInteractable ();
    }

    void ChangeScale()
    {
        if (GetComponent<Image>() == true && scaling == true)
        {
            //Changes scale
            scale += scalingSpeed;
            transform.localScale = new Vector2(scale, scale);

            //If the scale of the logo is 1 is greater then, stop scaling
            if (scale > 1)
            {
                scalingSpeed = 0;
            }
        }
    }

    void ChangeOpacity()
    {
        //Changes opacity
        opacity += opacitySpeed;
        if (GetComponent<Image>() == true)
        {
            GetComponent<Image>().color = new Color(1, 1, 1, opacity);
        }
        else if (GetComponent<Text>() == true)
        {
            GetComponentInChildren<Text>().color = new Color(1, 1, 1, opacity);
        }
            
        //If the opacity of the logo is greater then 1, stop changing the opacity
        if (opacity > 1)
        {
            opacitySpeed = 0;
        }
    }

	//DEZE METHOD IS OM DE INTERACTABLE VAN DE BUTTON PAS TRUE TE ZETTEN ALS 
	//DE OPACITY VAN DE KNOP VOLLEDIG IS.
	/*
	void CheckButtonInteractable(){
		/if (GetComponent<Button> () && ) {
		}
	}*/
}
