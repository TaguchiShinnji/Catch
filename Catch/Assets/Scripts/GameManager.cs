using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float m_magnification;

    //ゲームの速度
    private float m_gameSpeed;
    //ゲームのクリア数
    private static int m_clearCount = 0;
    //シングルトン
    static private GameManager m_instance = null;
    static public GameManager Instance { get { return m_instance; } }


    private static bool m_isClear;

    // Use this for initialization
    void Awake () {
        m_gameSpeed = 1.0f;
        m_instance = this;
    }

    public void AddClearCount()
    {
        m_clearCount++;
    }

    public void ResetClearCount()
    {
        m_clearCount = 0;
    }

    public float GetGameSpeed()
    {
        m_gameSpeed = (m_clearCount+1.0f) * m_magnification;

        return m_gameSpeed;
    }

    //ゲームカウントの入手
    public int GetGameCount()
    {
        return m_clearCount;
    }

    //ゲームリザルト///////////////////////////////
    public void SetResult(bool argIsClear)
    {
        m_isClear = argIsClear;
    }

    public bool GetResult()
    {
        return m_isClear;
    }
    //ゲームリザルト///////////////////////////////
}
