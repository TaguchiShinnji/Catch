using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCollisionModel : MonoBehaviour {

    [SerializeField]
    private GameObject m_collisonModel_L;
    [SerializeField]
    private GameObject m_collisonModel_R;

    [Tooltip("leapMotionカメラ内の左手の平(palm)用RigidBody")]
    [SerializeField]
    private GameObject m_palmModel_L;
    [Tooltip("leapMotionカメラ内の右手の平(palm)用RigidBody")]
    [SerializeField]
    private GameObject m_palmModel_R;


    [Tooltip("leapMotionカメラ内の左手モデル")]
    [SerializeField]
    private GameObject m_capsuleHand_L;
    private float m_notActiveTimer_L = 0f;

    [Tooltip("leapMotionカメラ内の右手モデル")]
    [SerializeField]
    private GameObject m_capsuleHand_R;
    private float m_notActiveTimer_R = 0f;

    public Vector3 posPalm;
    public Vector3 posCol;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (m_collisonModel_L.transform.position == m_palmModel_L.transform.position)
        {
            m_notActiveTimer_L += Time.deltaTime;
            if (m_notActiveTimer_L >= 0.1f)
            {
                m_capsuleHand_L.SetActive(false);
            }
        }
        else
        {
            m_notActiveTimer_L = 0;
            m_capsuleHand_L.SetActive(true);
        }

        if (m_collisonModel_R.transform.position == m_palmModel_R.transform.position)
        {
            m_notActiveTimer_R += Time.deltaTime;
            if (m_notActiveTimer_R >= 0.1f)
            {
                m_capsuleHand_R.SetActive(false);
            }
        }
        else
        {
            m_capsuleHand_R.SetActive(true);
        }

        //移動
        m_collisonModel_L.transform.position = m_palmModel_L.transform.position;
        m_collisonModel_R.transform.position = m_palmModel_R.transform.position;
        //回転
        m_collisonModel_L.transform.rotation = m_palmModel_L.transform.rotation;
        m_collisonModel_R.transform.rotation = m_palmModel_R.transform.rotation;
    }
}
