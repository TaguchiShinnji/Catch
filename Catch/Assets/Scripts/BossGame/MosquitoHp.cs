using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MosquitoHp : MonoBehaviour {

    //[HelpURL]

    private int HealthPointNow;
    [SerializeField]
    private int HealthPointMax;

    //[Range(0, 10)]
    private const int damage = 200;

    [Tooltip("蚊の体力を表示するもの")]
    public Text HPText;

    //
    static private MosquitoHp m_instance = null;
    static public MosquitoHp Instance { get { return m_instance; } }

    [SerializeField]
    private Image gaugeImage;
    private float perccentageArmorPoint;

    // Use this for initialization
    void Awake () {
        HealthPointNow = HealthPointMax;
        m_instance = this;
    }
	
	// Update is called once per frame
	void Update () {
        //体力をUI Textに表示する
        HPText.text = HealthPointNow.ToString() + "/" + HealthPointMax.ToString();
        gaugeImage.transform.localScale = new Vector3(perccentageArmorPoint, 1, 1);
        perccentageArmorPoint = (float)HealthPointNow / (float)HealthPointMax;
    }

    //蚊にダメージを与える
    public void Damaged()
    {
        HealthPointNow -= damage;
        HealthPointNow = Mathf.Clamp(HealthPointNow, 0, HealthPointMax);
    }

   //蚊が死んでいるかを確認
    public bool GetDead()
    {
        if (HealthPointNow <= 0)
        {
            return true;
        }
        return false;
    }
}
