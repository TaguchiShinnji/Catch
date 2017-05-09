using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSpritesAnimationSCR : MonoBehaviour
{
    [Tooltip("文字の「数」と「画像」")]
    [SerializeField]
    GameObject[] m_prefabs;

    [Tooltip("文字の「間隔」")]
    [SerializeField]
    float m_space;

    // 「Instantiate」されたオブジェクト達 (2017/05/04 14:43) Shinji.
    private GameObject[] m_gameObjects;

    // 「Animator」 (2017/05/04 16:03) Shinji.
    private Animator[] m_animators;

    void Start()
    {
        // [m_prefabs]が存在しない場合 (2017/05/06 15:33) Shinji.
        if (m_prefabs.Length == 0)
        {
            // 自分自身のスクリプトを削除する (2017/05/06 15:34) Shinji.
            Destroy(this);
        }

        // [m_prefabs]を生成して[m_gameObjects]に代入する (2017/05/04 14:49) Shinji.
        FetchGameObjectsFromPrefabs();

        // [m_animators]を取得する (2017/05/04 16:04) Shinji.
        FetchAnimatorToGameObjects();
    }

    // [m_prefabs]を生成して[m_gameObjects]に代入する (2017/05/04 14:54) Shinji.
    void FetchGameObjectsFromPrefabs()
    {
        // [m_prefabs]の配列の大きさ
        int length = m_prefabs.Length;

        // [m_prefabs]と同じ大きさの[m_gameObjects]を生成する (2017/05/04 15:01) Shinji.
        m_gameObjects = new GameObject[length];

        // 画像の設置場所 (2017/05/06 15:36) Shinji.
        Vector3 position;

        // [m_prefabs]から[m_gameObjects]を生成する (2017/05/04 15:03) Shinji.
        for (int i = 0; i < length; i++)
        {
            // 中心座標で設定する (2017/05/06 15:37) Shinji.
            position.x = Screen.width / 2;
            position.y = Screen.height / 2;
            position.z = 0;

            // 座標をずらす (2017/05/06 15:39) Shinji.
            position.x += (i - length / 2) * m_space;

            // 生成と格納をする (2017/05/04 15:03) Shinji.
            m_gameObjects[i] = Instantiate(m_prefabs[i], position, Quaternion.identity);

            // 親を設定する→UI用の[Canvas]の張り付けるため (2017/05/04 15:04) Shinji.
            m_gameObjects[i].transform.parent = this.transform;
        }
    }

    // [m_animators]を設定する (2017/05/05 18:02) Shinji.
    void FetchAnimatorToGameObjects()
    {
        // [m_gameObjects]の数だけ[m_animators]を作成する (2017/05/05 18:03) Shinji.
        m_animators = new Animator[m_gameObjects.Length];

        // [m_animators]を設定する (2017/05/05 18:04) Shinji.
        for (int i = 0; i < m_gameObjects.Length; i++)
        {
            m_animators[i] = m_gameObjects[i].GetComponent<Animator>();
        }
    }

    void Update()
    {
        // 拡大のアニメーションが終了していない (2017/05/05 19:08) Shinji.
        AnimatorStateInfo stateInfo = m_animators[m_animators.Length - 1].GetCurrentAnimatorStateInfo(0);

        // フェードアウトのアニメーションが実行中 (2017/05/06 15:56) Shinji.
        if (stateInfo.IsName("FadeOut"))
        {
            // フェードアウトのアニメーションが終了した (2017/05/06 15:56) Shinji.
            if (stateInfo.normalizedTime > 1)
            {
                // [m_gameObjects]を削除する (2017/05/06 15:57) Shinji.
                for (int i = 0; i < m_gameObjects.Length; i++)
                {
                    Destroy(m_gameObjects[i]);
                }
                // 自分自身の「スクリプト」を削除する (2017/05/06 15:57) Shinji.
                Destroy(this);
            }
        }    
    }
}