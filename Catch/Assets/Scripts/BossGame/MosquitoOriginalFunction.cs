using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MosquitoOriginalFunction : CheckHandsCollisionSCR
{
    // ゲーム  ごとに異なる特別な関数を呼ぶ
    protected override void SpecialFunction(GameObject gameObjectA)
    {
        Debug.Log("成功******************");
        AudioManager.Instance.PlaySE(1);
        // プレハブを取得
        GameObject prefabParticle = (GameObject)Resources.Load("Prefabs/Mosquito/MosquitoBlood");
        // プレハブからインスタンスを生成
        Instantiate(prefabParticle, gameObjectA.transform.position, Quaternion.identity);

        MosquitoHp.Instance.Damaged();

        if (MosquitoHp.Instance.GetDead())
        {
            StartCoroutine("DilayFunction");
        }
    }
    private IEnumerator DilayFunction()
    {
        yield return new WaitForSeconds(2.0f);
        //シーンを切り替える
        SceneManager.LoadScene("TitleScene");
    }
}
