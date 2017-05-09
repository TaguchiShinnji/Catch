using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAutoDelate : MonoBehaviour {

    private float m_timer;
	// Use this for initialization
	void Awake () {
		m_timer=0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        m_timer += Time.deltaTime;
        if(m_timer>=3.0f)
        {
            Destroy(this);
        }
	}
}
