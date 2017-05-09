using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour {

    [SerializeField]
    private AudioClip[] m_audioClip;

    private AudioSource m_audioSource;

    // Use this for initialization
    void Awake () {
        m_audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayBGM(int number)
    {
        m_audioSource.clip = m_audioClip[number];
        m_audioSource.loop = true;
        m_audioSource.Play();
    }
}
