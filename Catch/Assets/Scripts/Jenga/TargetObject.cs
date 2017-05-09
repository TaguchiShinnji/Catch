using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObject : MonoBehaviour {
    List<GameObject> colideObjects;

    void Awake()
    {
        // 動的配列を初期化する
        colideObjects = new List<GameObject>();
    }

    void Update()
    {
        bool IsConnect = true;
        for(int i=0;i<colideObjects.Count;i++)
        {
            if(colideObjects[i].tag == "Around")
            {
                Debug.Log("接しています");
                IsConnect = false;
               // colideObjects[i]
                break;
            }
        }
        if(IsConnect)
        {
            Debug.Log("ゲームクリア");
        }
    }

    // 物体と衝突が開始した瞬間
    private void OnCollisionEnter(Collision collision)
    {
        // 動的配列に追加する
        colideObjects.Add(collision.gameObject);
    }

    //  // 「衝突しているオブジェクトの動的配列」を取得する
    public List<GameObject> GetCollisions()
    {
        return colideObjects;
    }

    public void RemoveObjectToList(GameObject instance)
    {
        // 動的配列の中から同じオブジェクトのインデックスを取得する
        int index = colideObjects.IndexOf(instance.gameObject);
        // 見つかったインデックスのオブジェクト本体を削除する
        colideObjects.RemoveAt(index);
    }
}
