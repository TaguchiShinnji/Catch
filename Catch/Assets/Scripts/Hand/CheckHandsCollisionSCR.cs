using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHandsCollisionSCR : MonoBehaviour
{
    // 左手の当たり判定
    public GameObject m_handL;
    // 右手の当たり判定
    public GameObject m_handR;

    [SerializeField]
    private HandCollisionSCR handL;
    [SerializeField]
    private HandCollisionSCR handR;

    /***追記***/
    [Tooltip("触れられる回数の限界値")]
    [SerializeField]
    private int m_catchMax;//派生先で設定

    /***追記***/
    private int m_catchNow;//現在つかんだ数

    void Start ()
    {
		
	}
	
	void Update ()
    {
        bool hit = false;
        // 左手と衝突している物体を取得する
        List<GameObject> gameObjectsL;
        //gameObjectsL = m_handL.GetComponent<HandCollisionSCR>().GetCollisions();
        gameObjectsL = handL.GetCollisions();

        // 右手と衝突している物体を取得する
        List<GameObject> gameObjectsR;
        //gameObjectsR = m_handR.GetComponent<HandCollisionSCR>().GetCollisions();
        gameObjectsR = handR.GetCollisions();

        // 左手と衝突している物体の全部を検出する
        for (int l = 0; l < gameObjectsL.Count; l++)
        {
            // 右手と衝突している物体の全部を検出する
            for (int r = 0; r < gameObjectsR.Count; r++)
            {
                // 「左手と衝突している物体」と「右手と衝突している物体」が同じ
                if (gameObjectsL[l] == gameObjectsR[r])
                {
                    Catch(gameObjectsL[l]);
                    hit = true;
                    AudioManager.Instance.PlaySE(0);
                    var destoryObject = gameObjectsL[l];
                    m_catchNow++;/***追記***/

                    if (m_catchNow>=m_catchMax)/***追記***/
                    {
                        // ゲームごとに異なる特別な関数を呼ぶ
                        SpecialFunction(destoryObject);
                        //手の当たってるオブジェクトリストから削除する
                        handL.RemoveObjectToList(destoryObject);
                        handR.RemoveObjectToList(destoryObject);
                        m_catchNow = 0;/***追記***/
                    }
                }
            }
        }
        //キャッチしてない時に呼ばれる関数
        if(hit==false)
        {
            NotCatch();
        }
    }

    // ゲームごとに異なる特別な関数を呼ぶ
    protected virtual void SpecialFunction(GameObject gameObject)
    {

    }
    // ゲームごとに異なる特別な関数を呼ぶ
    protected virtual void Catch(GameObject gameObject)
    {

    }
    // ゲームごとに異なる特別な関数を呼ぶ
    protected virtual void NotCatch()
    {

    }

}
