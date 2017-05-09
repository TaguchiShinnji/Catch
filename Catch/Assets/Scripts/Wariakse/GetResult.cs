using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetResult : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameManager.Instance.AddClearCount();
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        Debug.Log(GameManager.Instance.GetResult());
        Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

        //クリアだった時のシーンへ移行
        if (GameManager.Instance.GetResult())
        {
            SceneManager.LoadScene("ClearScene");
        }
        //失敗したときのシーンへ移行
        else
        {
            SceneManager.LoadScene("MissScene");
        }
	}
}
