using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarikaseClear : MonoBehaviour {

    //手のオブジェクト
    [SerializeField]
    private GameObject handR, handL;

    //移動速度
    private float moveSpeed;
    //最初の時間
    private float startTime;
    //スプライトの最初の場所
    private Vector3 startPosR, startPosL;
    //目的地
    [SerializeField]
    private Vector3 endPos;

    //死ぬ蚊のオブジェクト
    [SerializeField]
    private GameObject Diemosquito;
    //蚊の初期位置
    private Vector3 DiemosquitoPos;

    //最初の時間
    public float diff;
    //時間による進む距離
    public float rate;

    //制限時間
    [SerializeField]
    private float TIME_LIMIT;

    //手を動かす時間
    [SerializeField]
    private float HAND_TIME;

    // Use this for initialization
    void Start () {
        TIME_LIMIT = 5.0f;
        //最初の時間を受け取る
        startTime = Time.timeSinceLevelLoad;
        //スプライトの最初の場所を設定
        startPosR = handR.transform.position;
        startPosL = handL.transform.position;
        //死ぬときの蚊の初期位置
        DiemosquitoPos = Diemosquito.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        CountDown();
        //手を動かす
        if (handR)
        {
            //TIME_LIMITまでにendPosに移動
            handR.transform.position = Vector3.Lerp(startPosR, endPos, rate);
        }
        //手を動かす
        if (handL)
        {
            //TIME_LIMITまでにendPosに移動
            handL.transform.position = Vector3.Lerp(startPosL, endPos, rate);
        }
        //達したら手を消す
        if (diff > TIME_LIMIT)
        {
            //オブジェクトを消す
            Destroy(handR);
            Destroy(handL);
            Destroy(Diemosquito);
        }
	}

    //時間を減らす
    private void CountDown()
    {
        //時間をゲームスピードに合わせて減らす
        diff = Time.timeSinceLevelLoad - startTime * GameManager.Instance.GetGameSpeed();
        //時間によって移動する距離を出す
        rate = diff / TIME_LIMIT;
    }
}
