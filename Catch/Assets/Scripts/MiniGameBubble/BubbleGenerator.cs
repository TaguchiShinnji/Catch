using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleGenerator : MonoBehaviour {
    private float timer;
	// Use this for initialization
	void Start () {
        timer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime*GameManager.Instance.GetGameSpeed();
        if (timer >= 3.0f)
        {
            // プレハブを取得
            GameObject prefab = (GameObject)Resources.Load("Prefabs/Bubble/Bubble");
            // プレハブからインスタンスを生成
            Instantiate(prefab, new Vector3(Random.Range(-0.3f, 0.3f), -0.4f, 0.625f), Quaternion.identity);
            BallMove.Instance.MoveStart();
            timer = 0.0f;
        }
    }
}