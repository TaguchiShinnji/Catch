using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleOriginalFunction: CheckHandsCollisionSCR
{
    [Tooltip("タイトルシーンのパーティクル")]
    [SerializeField]
    private ParticleSystem m_titleParticle;
    // ゲームごとに異なる特別な関数を呼ぶ
    protected override void SpecialFunction(GameObject gameObject)
    {
        AudioManager.Instance.PlaySE(0);
        StartObject.m_isMove = false;//モデルの動きを止める

        //パーティクルを出す
        m_titleParticle.Play();

        //掌を青に変更
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
        //シーン遷移
        StartCoroutine("DilayFunction");
    }

    private IEnumerator DilayFunction()
    {
        yield return new WaitForSeconds(1);
        //シーンを切り替える
        //SceneManager.LoadScene("WarikaseScene");
    }
}