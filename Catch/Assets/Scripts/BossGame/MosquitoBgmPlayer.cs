using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoBgmPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        AudioManager.Instance.PlayBGM(4);
    }
}
