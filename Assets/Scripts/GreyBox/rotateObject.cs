using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateObject : MonoBehaviour {

	// public variables ---------------------
	public float m_speed;
	public bool m_zAxe;

	// private variables --------------------

	// --------------------------------------
	// Use this for initialization
	// --------------------------------------
	void Start () {
		
	}
	
	// --------------------------------------
	// Update is called once per frame
	// --------------------------------------
	void Update () {
		if (!m_zAxe)
			gameObject.transform.Rotate(0, m_speed, 0);
		
		if (m_zAxe)
			gameObject.transform.Rotate(0, 0, m_speed);
	}

	// --------------------------------------
	// Methods
	// --------------------------------------
}
