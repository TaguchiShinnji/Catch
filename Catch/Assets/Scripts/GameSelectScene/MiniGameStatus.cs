using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameStatus : MonoBehaviour{
    [SerializeField]
    private int m_gameNumber;//各ゲームの番号(int)enumの値

    [Tooltip("難易度。五段階で設定")]
    [SerializeField]
    private int m_difficulty;//難易度

    [Tooltip("ゲームの系統 1:挟む系 2:その他")]
    [SerializeField]
    private int m_type;

    [SerializeField]
    private bool m_isPlayed;

    //選ばれたらシーンを飛ばす
    public void IsSelected()
    {
        switch (m_gameNumber)
        {
            case 0://拍手
                Debug.Log("拍手に移動");
                break;
            case 1://白羽取り
                Debug.Log("白羽取りに移動");
                break;
            case 2://シャボン玉
                //SceneManager.LoadScene("BubbleScene");
                Debug.Log("シャボンに移動");
                break;
        }
        //Debug.Log(m_gameNumber+"シーンを移動");
    }

    //難易度を入手
    public int GetDifficulty()
    {
        return m_difficulty;
    }

    //ゲーム番号を入手
    public int GetGameNumber()
    {
        return m_gameNumber;
    }

    //所属を入手
    public int GetGameType()
    {
        return m_type;
    }

    //プレイ済みかどうかチェック
    public bool IsPlayed()
    {
        return m_isPlayed;
    }

    //プレイ済みに設定
    public void SetPlayed()
    {
        //GameManager.Instance.AddGameNumber(m_gameNumber);//ゲーム番号をクリア済みリストに追加
        m_isPlayed = true;
    }

    public void ResetPlayed()
    {
        m_isPlayed = false;
    }
}