using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour {

    private Vector3 m_speed;
    private bool m_isMove;

    //シングルトン
    static private BallMove m_instance = null;
    static public BallMove Instance { get { return m_instance; } }
    // Use this for initialization
    void Start () {
        m_speed = new Vector3(0,0,-GameManager.Instance.GetGameSpeed()*0.02f);
        m_isMove = true;
        m_instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        if (m_isMove)
        {
            this.transform.position += m_speed;
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        //シャボンを一定時間で破壊(はさみそこなった時)
        if (collision.gameObject.CompareTag("Target"))
        {
            Destroy(this.gameObject);//破壊する
            Debug.Log("失敗");
        }
    }

    public void MoveStop()
    {
        m_isMove = false;
    }

    public void MoveStart()
    {
        m_isMove = true;
    }
}
