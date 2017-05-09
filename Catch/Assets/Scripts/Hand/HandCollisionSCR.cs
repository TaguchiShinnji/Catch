using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollisionSCR : MonoBehaviour
{
    // 現在、衝突しているオブジェクトの動的配列
    private List<GameObject> m_collisionObjects;

    void Awake()
    {
        // 動的配列を初期化する
        m_collisionObjects = new List<GameObject>();
    }
	
	void Update ()
    {

	}

    // 物体と衝突が開始した瞬間
    private void OnCollisionEnter(Collision collision)
    {
        // 動的配列に追加する
        m_collisionObjects.Add(collision.gameObject);
    }

    // 物体と衝突が終了した瞬間
    private void OnCollisionExit(Collision collision)
    {
        //// 動的配列の中から同じオブジェクトのインデックスを取得する
        //int index = m_collisionObjects.IndexOf(collision.gameObject);
        //// 見つかったインデックスのオブジェクト本体を削除する
        //m_collisionObjects.RemoveAt(index);
    }

    //  // 「衝突しているオブジェクトの動的配列」を取得する
    public List<GameObject> GetCollisions()
    {
        return m_collisionObjects;
    }

    public void RemoveObjectToList(GameObject instance)
    {
        // 動的配列の中から同じオブジェクトのインデックスを取得する
        int index = m_collisionObjects.IndexOf(instance.gameObject);
        // 見つかったインデックスのオブジェクト本体を削除する
        m_collisionObjects.RemoveAt(index);
    }
}
