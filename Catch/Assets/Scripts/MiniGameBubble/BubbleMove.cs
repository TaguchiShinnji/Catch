using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMove : MonoBehaviour {
	// Update is called once per frame
	void Update () {
        //上に飛んでいく
        this.transform.position += new Vector3(0.0f,0.008f+GameManager.Instance.GetGameSpeed()/0.001f,0.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //シャボンを一定時間で破壊(はさみそこなった時)
        if (collision.gameObject.CompareTag("Target"))
        {
            //move to this object to above.
            AudioManager.Instance.PlaySE(1);
            // プレハブを取得
            GameObject prefabParticle = (GameObject)Resources.Load("Prefabs/Bubble/Bubble Particle");
            // プレハブからインスタンスを生成
            Instantiate(prefabParticle, gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);//破壊する
            Debug.Log("失敗");
        }
    }
}

