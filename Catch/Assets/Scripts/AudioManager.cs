using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    //イニウムで設定してもらう


    public static AudioManager m_instance;
    public static AudioManager Instance { get { return m_instance; } }

    [SerializeField]
    private BGMManager m_BgmManager;
    [SerializeField]
    private SEManager m_SEManager;

    // Use this for initialization
    void Awake () {
        m_instance = this;
        //m_BgmManager.PlayBGM(0);
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void PlayBGM(int number)
    {
        m_BgmManager.PlayBGM(number);
    }

    public void PlaySE(int number)
    {
        m_SEManager.PlaySE(number);
    }
}
