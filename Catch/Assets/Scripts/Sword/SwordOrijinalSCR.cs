using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwordOrijinalSCR : CheckHandsCollisionSCR
{
    // 剣のオブジェクト
    public GameObject m_sword;

    // ゲームの結果
    public bool m_result = false;


    [Tooltip("エフェクト")]
    [SerializeField]
    private ParticleSystem m_ps;


    void Start ()
    {
		
	}

    // ゲームごとに異なる特別な関数を呼ぶ
    protected override void SpecialFunction(GameObject gameObject)
    {
        if (m_result)
            return;

        // ターゲット(剣)を挟んだ場合
        if (gameObject.tag == "Target")
        {
            m_result = true;
            StartCoroutine("GameClear");

            // エフェクトを表示する (2017/05/04 14:43) Shinji.
            Instantiate(m_ps);
        }
        else 
        {
            m_result = false;
            Debug.Log("Miss...");
        }

    }

    private void LateUpdate()
    {
        if (m_result)
            return;

        bool result;
        result = m_sword.GetComponent<SwordSCR>().End();

        if(result)
        {
            m_result = false;
            Debug.Log("Miss...");
            GameManager.Instance.SetResult(false);
            SceneManager.LoadScene("ResultScene");
        }
    }
    private IEnumerator GameClear()
    {
        yield return new WaitForSeconds(1);
        //シーンを切り替える
        GameManager.Instance.SetResult(true);
        SceneManager.LoadScene("WarikaseScene");
    }
}
