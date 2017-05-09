using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudienceOrijinalSCR : CheckHandsCollisionSCR
{
    // クリアに必要な回数
    [SerializeField]
    private int m_clearCount;

    // 回数を保存
    [SerializeField]
    private int m_count;

    // 衝突しているオブジェクトを保存
    [SerializeField]
    private GameObject m_collisionObject;


    [SerializeField]
    private ParticleSystem m_ps;
    // 初期化
    private void Awake()
    {
        // 「０」で初期化する
        m_count = 0;
    }

    // ゲームごとに異なる特別な関数を呼ぶ
    protected override void Catch(GameObject gameObject)
    {
        Instantiate(m_ps);

        // 「衝突しているオブジェクト」と「引数のオブジェクト」が同じ
        if (m_collisionObject == gameObject)
        {
            // 処理を終える
            return;
        }

        // ターゲット(音符)以外を挟んだ場合
        if (gameObject.tag != "Target")
        {
            // 処理を終える
            return;
        }

        // 現在衝突しているオブジェクトを切り替える
        m_collisionObject = gameObject;

        // 叩いた回数を一回、増やす
        m_count++;

        // クリアに必要な回数を超えているか確認する
        if (m_count > m_clearCount)
        {
            GameManager.Instance.SetResult(true);
            SceneManager.LoadScene("ResultScene");
        }
    }
    // ゲームごとに異なる特別な関数を呼ぶ
    protected override void NotCatch()
    {
        // 現在衝突しているオブジェクトをnullにする→衝突していない
        m_collisionObject = null;
    }
}