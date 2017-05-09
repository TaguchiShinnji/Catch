using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoMove : MonoBehaviour {

    private float speedHeight;
    private float speedWidth;
    private float speedDepth;
    public float addSpeed;//加速
    private float timeCnt;

    // Use this for initialization
    void Awake() {
        speedHeight = 0.003f;
        speedWidth =  0.008f;
        speedDepth = 0.001f;
        addSpeed = 1.0f;
    }
	
	// Update is called once per frame
	void Update () {
        timeCnt += Time.deltaTime;
        if (timeCnt >= 3)
        {
            this.transform.position += new Vector3(speedWidth * addSpeed, speedHeight * addSpeed, speedDepth * addSpeed);
        }
        if (this.transform.position.x>=0.7f||this.transform.position.x<=-0.7f)
        {
            speedWidth *= -1.0f;
        }
        if (this.transform.position.y >= 0.4f || this.transform.position.y <= -0.4f)
        {
            speedHeight *= -1.0f;
        }
        if (this.transform.position.z >= 0.8f || this.transform.position.z <= 0.65f)
        {
            speedDepth *= -1.0f;
        }
    }
}
