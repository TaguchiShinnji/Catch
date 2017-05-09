using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JengaOriginal : CheckHandsCollisionSCR {

    // ゲーム  ごとに異なる特別な関数を呼ぶ
    protected override void SpecialFunction(GameObject gameObjectA)
    {

    }
    private IEnumerator DilayFunction()
    {
        yield return new WaitForSeconds(2.0f);
        //シーンを切り替える
        //SceneManager.LoadScene("ResultScene");
        Debug.Log("シーン切り替え");
    }
}
