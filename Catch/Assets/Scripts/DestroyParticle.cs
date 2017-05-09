using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour {
    private float timeCount;
	// Use this for initialization
	void Start () {
        timeCount = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        timeCount += Time.deltaTime;

        if(timeCount>=0.5f)
        {
            Destroy(this.gameObject);
        }
	}
}
