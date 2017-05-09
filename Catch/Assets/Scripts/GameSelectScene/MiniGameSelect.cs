using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameSelect : MonoBehaviour {
    //各ミニゲームのステートが入れられている
    [SerializeField]
    private MiniGameStatus[] miniGameArray;

    //遊び済みゲームの番号を格納
    private List<int> m_playedGameNumbers = new List<int>();

    private float m_timer;
    //抽選する箱の番号
    int m_boxNumber;
    int m_numMiniGame;
    // Use this for initialization
    void Awake () {
        m_boxNumber = 0;
        m_numMiniGame = 5;
        m_timer = 0.0f;
    }


    public static int m_count = 0;

    void Update()
    {
        if ( m_playedGameNumbers.Count> 0)
        {
            for (var i = 0; i < m_playedGameNumbers.Count; i++)//クリアした回数
            {
                miniGameArray[m_playedGameNumbers[i]].SetPlayed();//遊び済みに設定
            }
        }
        //時間を加算
        m_timer += Time.deltaTime;
        if (m_timer >= 0.5f)
        {
            //ゲームカウントが10より大きいなら    //【デバック時は３つ以内】
            if (m_count >= 10)
            {
                //  蚊のシーンにとぶ
                SceneManager.LoadScene("MosquitoScene");
                return;
            }
            else
            {
                //miniGameArray[ChoseMiniGames()].IsSelected();//シーン遷移【プロトで未使用】
                switch (m_count)
                {
                    case 0:
                        SceneManager.LoadScene("Audience");
                        break;
                    case 1:
                        SceneManager.LoadScene("Sword");
                        break;
                    case 2:
                        SceneManager.LoadScene("BubbleScene");
                        break;
                }
            }
        }
    }

    public int ChoseMiniGames()
    {
        m_boxNumber = 1 - m_boxNumber;

        List<int> miniGameBox = new List<int>();

        for (var i = 0; i < miniGameArray.Length; i++)
        {
            if (miniGameArray[i].IsPlayed()) continue;

            if (m_boxNumber == miniGameArray[i].GetGameType())
            {
                for (var j = 0; j < 6 - miniGameArray[i].GetDifficulty(); j++)
                {
                    miniGameBox.Add(miniGameArray[i].GetGameNumber());
                }
            }
        }
        
        //乱数で抽選
        int number = Random.Range(0, miniGameBox.Count);
        //抽選で引かれた値
        //あそぶゲームを遊び済みにする(選ばれたゲームの要素番号をいれる)
        m_playedGameNumbers.Add(miniGameBox[number]);
        //カウントをする
        m_count++;
        return miniGameBox[number];
    }
}