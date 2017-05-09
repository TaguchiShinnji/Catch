using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PVdisplay : MonoBehaviour {

    [SerializeField]
    private GameObject m_handL;//左手のモデル
    [SerializeField]
    private GameObject m_handR;//右手のモデル

    [SerializeField]
    private float timeCnt;//タイムカウンタ

    [Tooltip("PVを表示するまでに何秒検出されないか")]
    [SerializeField]
    float MoveScene;

	// Use this for initialization
	void Start () {
        AudioManager.Instance.PlayBGM(0);
    }
	
	// Update is called once per frame
	void Update () {
        //もし手の検出が切れていたら
        if (m_handL.activeSelf == false && m_handR.activeSelf == false)
        {
            timeCnt += Time.deltaTime;
        }
        else
        {
            timeCnt = 0.0f;
        }
        if (timeCnt >= MoveScene)
        {
            Debug.Log("PV_is_Start!<<<<<<<<<<<");
        }
	}
}
