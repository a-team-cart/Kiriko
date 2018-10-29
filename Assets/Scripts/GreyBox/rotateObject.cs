using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateObject : MonoBehaviour {

	// public variables ---------------------
	public float m_speed;

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
		gameObject.transform.Rotate(0, m_speed, 0);
		
	}

	// --------------------------------------
	// Methods
	// --------------------------------------
}
