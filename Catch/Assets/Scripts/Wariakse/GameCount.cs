using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCount : MonoBehaviour {

    public static float count = 0.0f;

	// Use this for initialization
	void Start () {
        count++;
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = count.ToString("00");
	}
}
