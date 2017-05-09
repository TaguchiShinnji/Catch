using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBgmInSwordScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
        AudioManager.Instance.PlayBGM(2);
	}
}
