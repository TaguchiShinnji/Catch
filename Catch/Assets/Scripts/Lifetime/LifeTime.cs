using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeTime : MonoBehaviour {

    //最大時間
    private float TIME_LIMIT;
    //アニメーション
    public Animation anim;

    //スプライトの右手と左手
    [SerializeField]
    private GameObject handR, handL;
    //風船のオブジェクト
    [SerializeField]
    private GameObject balloon;

    //最初の時間
    private float startTime;
    //手の最初のポジション
    private Vector3 startPositionR;
    private Vector3 startPositionL;
    //目的地(手のひらの位置)
    [SerializeField]
    private Vector3 endPosition;

    //最初の時間
    private float diff;
    //時間による進む距離
    private float rate;

    // Use tfloat ratehis for initialization
    void Start()
    {
        //最大時間
        TIME_LIMIT = 100.0f;
        //アニメーションのコンポーネント
        anim = GetComponent<Animation>();
        //最初の時間を受け取る
        startTime = Time.timeSinceLevelLoad;
        //右手の最初の場所を設定
        startPositionR = handR.transform.position;
        //左手の最初の場所を設定
        startPositionL = handL.transform.position;
        //目的地を風船の場所に指定する
        endPosition = balloon.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //カウントダウンを始める
        CountDown();
        //右手の移動       
        handR.transform.position = Vector3.Lerp(startPositionR, endPosition, rate);
        //左手の移動
        handL.transform.position = Vector3.Lerp(startPositionL, endPosition, rate);

        //Debug.Log(handR.transform.position);

        //MAX_TIME時間がたったら
        if (diff > TIME_LIMIT)
        {
            //バルーンが割れる処理
            Animation();
            //シーンを移動する
            SceneChange();
        }
        //デバッグ用
        //Debug.Log(transform.position);
    }

    //シーンを変更する
    void SceneChange()
    {
        //シーンの移動
        GameManager.Instance.SetResult(false);
        SceneManager.LoadScene("ResultScene");
    }

    //カウントを減らす処理
    void CountDown()
    {
        //時間をゲームスピードに合わせて減らす
        diff = Time.timeSinceLevelLoad - startTime * GameManager.Instance.GetGameSpeed();
        //1秒間に進む距離
        rate = diff / TIME_LIMIT;
    }

    //アニメーション処理
    void Animation()
    {
        //アニメーションを実行
        // anim.Play();
    }

    public float GetTimeLimit()
    {
        //時間を返す
        return TIME_LIMIT;
    }
}
