﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExitForProto : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1"))
        {
            Application.Quit();
        }
	}
}
