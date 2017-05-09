using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeeperOriginal : CheckHandsCollisionSCR
{

    private int m_clearCount = 5;//クリアに必要な回数
    public int m_hitCount = 0;//現在挟んだ関数

    private GameObject ballObj;
    // ゲーム  ごとに異なる特別な関数を呼ぶ
    protected override void SpecialFunction(GameObject gameObjectA)
    {
        Debug.Log("成功******************");
        // プレハブを取得
        GameObject prefabParticle = (GameObject)Resources.Load("Prefabs/Keeper/KeeperParticle");
        // プレハブからインスタンスを生成
        Instantiate(prefabParticle, gameObjectA.transform.position, Quaternion.identity);
        m_hitCount++;
        ballObj = gameObjectA;
        StartCoroutine("CatchFunc");
        bool over = CheckHitCountOverClearCount();
        if (over)
        {
            //シーン遷移のDilayをつける
            StartCoroutine("DilayFunction");
            //リザルトにClearを代入する
            GameManager.Instance.SetResult(true);
        }
    }
    private IEnumerator DilayFunction()
    {
        yield return new WaitForSeconds(1.0f);
        //シーンを切り替える
        //SceneManager.LoadScene("ResultScene");
        Debug.Log("成功>>>>>>>>>>>>>>>");
    }

    private IEnumerator CatchFunc()
    {
        //ballObj.transform.position = (m_handL.transform.position + m_handR.transform.position) / 2.0f;
        BallMove.Instance.MoveStop();
        yield return new WaitForSeconds(0.5f);
        Destroy(ballObj);
    }

    private bool CheckHitCountOverClearCount()
    {
        bool result = false;
        if (m_hitCount >= m_clearCount)
        {
            result = true;
        }
        return result;
    }
}
