using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MoveBackground : MonoBehaviour
{
    public float speed = 1f;
    public GameObject obj1;
    public Vector2 startPos;

    // Use this for initialization 28
    void Start()
    {
        startPos = new Vector2(0, (float) 11.5);

    }

    // Update is called once per frame
    void Update ()
    {
        moveImage();
    }

    void moveImage()
    {
        transform.Translate(0, -speed * Time.deltaTime, 0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "FrontCollider")
        {
            this.transform.position = startPos;
            print(startPos.ToString());
        }
    }
}
