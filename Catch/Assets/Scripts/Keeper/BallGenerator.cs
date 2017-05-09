using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour {

    private float timer;
    // Use this for initialization
    void Start()
    {
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 3.0f)
        {
            // プレハブを取得
            GameObject prefab = (GameObject)Resources.Load("Prefabs/Keeper/Ball");
            // プレハブからインスタンスを生成
            Instantiate(prefab, new Vector3(0, -0.12f, 2.4f), Quaternion.identity);
            timer = 0.0f;
        }
    }
}
