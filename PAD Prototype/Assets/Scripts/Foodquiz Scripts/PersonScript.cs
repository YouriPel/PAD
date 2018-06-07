using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonScript : MonoBehaviour {

    public int score;
    public string username;

    public void SetPersonDetails() {
        this.transform.GetChild(1).gameObject.GetComponent<Text>().text = score.ToString();
        this.transform.GetChild(0).gameObject.GetComponent<Text>().text = username;
    }
}
