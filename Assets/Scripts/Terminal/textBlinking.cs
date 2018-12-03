using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textBlinking : MonoBehaviour {

	// public variables ---------------------
	public float m_timeLimit;
	public GameObject m_textBlink;

	// private variables --------------------
	private float m_counter;
	private bool m_showText;

	// --------------------------------------
	// Use this for initialization
	// --------------------------------------
	void Start () {
		m_counter = 0f;
		m_showText = true;
		
	}
	
	// --------------------------------------
	// Update is called once per frame
	// --------------------------------------
	void Update () {
		m_counter += Time.deltaTime;

		if (m_counter > m_timeLimit) {
			m_showText = !m_showText;
			m_counter = 0f;
		}

		if (m_showText)
			m_textBlink.SetActive(true);

		if (!m_showText)
			m_textBlink.SetActive(false);

		
	}

	// --------------------------------------
	// Update is called once per frame
	// --------------------------------------
}
