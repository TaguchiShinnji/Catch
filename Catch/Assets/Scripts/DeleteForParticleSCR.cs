using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteForParticleSCR : MonoBehaviour
{
    [Tooltip("削除までの時間")]
    [SerializeField]
    private float m_lifeTime;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        m_lifeTime -= Time.deltaTime;

        if(m_lifeTime < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
