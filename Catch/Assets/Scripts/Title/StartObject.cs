using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartObject : MonoBehaviour {

    public static bool m_isMove;//動くかどうか

	// Use this for initialization
	void Start () {
        m_isMove = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (m_isMove == true)
        {
            this.gameObject.transform.position -= new Vector3(0.0f, 0.02f, 0.0f);//下降

            if (this.gameObject.transform.position.y <= -1.8f)
            {
                this.gameObject.transform.position = new Vector3(-0.01f, 0.345f, 0.52f);//初期位置
            }
        }
	}
}
