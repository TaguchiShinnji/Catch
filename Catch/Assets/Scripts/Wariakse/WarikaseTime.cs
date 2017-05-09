using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarikaseTime : MonoBehaviour {
    //ワリカセの最大時間
    [SerializeField]
    private float TIME_LIMIT;
    
    //スプライト
    [SerializeField]
    private GameObject sprite;
    //移動速度
    private float moveSpeed;
    //最初の時間
    private float startTime;
    //スプライトの最初の場所
    private Vector3 startPosition;
    //目的地
    [SerializeField]
    private Vector3 endPosition;

    //最初の時間
    public float diff;
    //時間による進む距離
    public float rate;

    //移動速度
    //private float moveCamera;
    //最初の時間
    private float CameraTime;

    //最初の時間
    public float start;
    //時間による進む距離
    public float end;

    //スプライトの場所を設定
    private Vector3 CameraStart;
    //カメラの目的地
   public Vector3 endCameraPosition;

    //カメラをアップする時間
    [SerializeField]
    private float TIME_CAMERA;

    //現在のライフ
    [SerializeField]
    private int life_Num;
    //最大ライフ
    const int LIFE_MAX = 4;

    [SerializeField]
    private float CAMERA_TIME;

    private Camera MIcamera;

    // Use this for initialization
    void Start () {
        //制限時間
        //TIME_LIMIT = 5.0f;
        //カメラの拡大時間
        CAMERA_TIME = TIME_LIMIT + 1.0f;
        //最初の時間を受け取る
        startTime = Time.timeSinceLevelLoad;
        //スプライトの最初の場所を設定
        startPosition = sprite.transform.position;
        //ライフを設定
        life_Num = LIFE_MAX;
        //最初の時間を受け取る
        CameraTime = Time.timeSinceLevelLoad - startTime;
        //カメラ
        MIcamera = Camera.main;
        //カメラの最初の位置を受け取る
        CameraStart = endPosition;

        AudioManager.Instance.PlayBGM(0);
        
    }
	
	// Update is called once per frame
	void Update () {
        //カウントダウンを行う
        CountDown();
        //移動を行う
        sprite.transform.position = Vector3.Lerp(startPosition, endPosition, rate);

        //時間がたったら
        if (diff > TIME_LIMIT)
        {
            //--------------------蚊を近づかせるようにしておく------------------------------
            //時間をゲームスピードに合わせて減らす
            start = Time.timeSinceLevelLoad - CameraTime * GameManager.Instance.GetGameSpeed();
            //時間によって移動する距離を求める
            end = start / CAMERA_TIME;
            //カメラの移動
            sprite.transform.position = Vector3.Lerp(CameraStart, endCameraPosition, end);
            //--------------------------------------------------------------------------------

            if(start > CAMERA_TIME)
            {
                SceneChenger();
            }
        }
	}

    //シーン移行を行う関数
    void SceneChenger()
    {
        //ゲームセレクトシーンへ移行する
        SceneManager.LoadScene("MiniGameSelect");
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
