using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MoveImage : MonoBehaviour
{
    Vector2 startPos;
    public float speed;
    private float height;
    private RectTransform rt;
    void Start()
    {
        rt = this.GetComponent<RectTransform>();
        height = rt.rect.height;
        startPos = new Vector2(0, height);//Y pos is equal to height of image
    }

    void Update()
    {
        transform.Translate(0, -speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "bottomCollider")
        {
            rt.anchoredPosition = startPos;
        }
    }
}
