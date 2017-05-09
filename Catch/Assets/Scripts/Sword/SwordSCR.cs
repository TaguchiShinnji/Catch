using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSCR : MonoBehaviour
{
    // ゲームの速度(本体)
    private float m_speed;

    // 剣を振り下ろすタイミング
    [SerializeField]
    private float m_timing;

    // 剣の状態の種類
    enum Type
    {
        Ready,
        Start,
        End,
    };

    // 剣の状態
    private Type m_type;

    // 終了
    private bool m_end;

    void Start ()
    {
        // ゲームの速度(本体)
        m_speed = GameManager.Instance.GetGameSpeed();

        // 剣の状態を準備状態にする
        m_type = Type.Ready;
    }
	
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            m_type = Type.Start;
        }




        if (m_type == Type.Ready)
        {
            m_timing -= Time.deltaTime;

            if (m_timing <= 0)
            {
                m_type = Type.Start;
            }
        }



        switch (m_type)
        {
            case Type.Ready:
                // 待機
                Wait();
                break;
            case Type.Start:
                // 振り下ろす
                Swing();
                break;
            case Type.End:
              break;
            }
	}

    // 振り下ろす速度
    [SerializeField]
    private float m_rotSpd;

    private bool m_waitFlag = true;

    // 待機
    void Wait()
    {
        float rotX;
        rotX = this.gameObject.transform.localRotation.x;

        if (m_waitFlag == true)
        {
            if (rotX > -0.3f)
            {
                float rand = Random.Range(0.5f, 2.0f);

                this.gameObject.transform.Rotate(new Vector3(-m_rotSpd * m_speed * rand, 0f, 0f));
            }
            else
            {
                m_waitFlag = false;
            }
        }
        else
        {
            if (rotX < 0.05f)
            {
                this.gameObject.transform.Rotate(new Vector3(m_rotSpd * m_speed, 0f, 0f));
            }
            else
            {
                m_waitFlag = true;
            }
        }
    }

    // 振り下ろす
    void Swing()
    {
        float rotX;
        rotX = this.gameObject.transform.localRotation.x;

        if(rotX > -0.85f)
        {
            this.gameObject.transform.Rotate(new Vector3(-m_rotSpd*m_speed, 0f, 0f));
        }
        else
        {
            m_type = Type.End;
            m_end = true;
        }
    }

    // 終了したか否か
    public bool End()
    {
        return m_end;
    }
}


