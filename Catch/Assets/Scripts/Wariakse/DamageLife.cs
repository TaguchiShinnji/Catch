using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageLife : MonoBehaviour {

    //最大ライフ
    private static int lifeMax = 4;

    //現在のライフ
    private static int lifeNum = lifeMax;

    //ライフのオブジェクト
    public GameObject[] lifeObject;

	// Use this for initialization
	void Start () {
        //ライフを減らす
        lifeNum -= 1;
	}
	
	// Update is called once per frame
	void Update () {
         //オブジェクトを削除
         Destroy(lifeObject[lifeNum]);
	}

    //ライフを減らすアニメーションを行う(後でする)
    void Animation()
    {

    }
}
