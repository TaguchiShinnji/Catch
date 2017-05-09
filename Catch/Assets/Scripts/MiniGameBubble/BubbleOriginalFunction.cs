using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BubbleOriginalFunction : CheckHandsCollisionSCR
{
    private int m_clearCount=5;//クリアに必要な回数
    private int m_hitCount=0;//現在挟んだ関数

    // ゲーム  ごとに異なる特別な関数を呼ぶ
    protected override void SpecialFunction(GameObject gameObjectA)
    {
        Debug.Log("成功******************");
        AudioManager.Instance.PlaySE(1);
        // プレハブを取得
        GameObject prefabParticle = (GameObject)Resources.Load("Prefabs/Bubble/Bubble Particle");
        // プレハブからインスタンスを生成
        Instantiate(prefabParticle, gameObjectA.transform.position, Quaternion.identity);
        m_hitCount++;
        Destroy(gameObjectA);

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
        yield return new WaitForSeconds(2.0f);
        //シーンを切り替える
        SceneManager.LoadScene("ResultScene");
    }

    private bool CheckHitCountOverClearCount()
    {
        bool result=false;
        if(m_hitCount>=m_clearCount)
        {
            result = true;
        }
        return result;
    }
}