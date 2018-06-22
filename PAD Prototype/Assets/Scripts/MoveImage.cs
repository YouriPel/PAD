using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveImage : MonoBehaviour
{
    Vector2 startPos;
    //Moving speed
    public float speed;
    private float height;
    //Transform(position,scaling,rotation) for UI component
    private RectTransform rt;
    void Start()
    {
        //Puts background image in rt
        rt = this.GetComponent<RectTransform>();
        //Gets background image height
        height = rt.rect.height;
        /*start position of the image
        Y pos is equal to height of image*/
        startPos = new Vector2(0, height);
    }

    void Update()
    {
        //Transforms y position
        transform.Translate(0, -speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        //If background image hits the collider
        if (coll.gameObject.name == "bottomCollider")
        {
            //Puts background image back to the start position
            rt.anchoredPosition = startPos;
        }
    }
}
