using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelController : MonoBehaviour {

	// public variables --------------------
	public bool m_activate;
	[HideInInspector]public float m_timer;
	public float m_timerLimit = 5f;

	// private variables -------------------
	private float m_panelWidth;
	private RectTransform m_rt;
	private float m_animationSpeed = 0.05f;
	private float m_panelMaxWidth = 1f;

	// -------------------------------------
	// Use this for initialization
	// -------------------------------------
	void Start () {
		// Disable panels
		m_panelWidth = 0f;

		// Get the Rect Transform
		m_rt = gameObject.GetComponent<RectTransform>();

		// Update changes
		m_rt.localScale = new Vector3 (m_panelWidth, 1f, 1f);	
	}
	
	// -------------------------------------
	// Update is called once per frame
	// -------------------------------------
	void Update () {
		// Start activation animation
		if (m_activate)
			activateDescription();

		// Start closing animation
		if (!m_activate)
			desableDescription();
		
	}

	// -------------------------------------
	// Methods
	// -------------------------------------
	private void activateDescription() {
		m_timer += Time.deltaTime;

		// Change the width of the Panel
		if (m_panelWidth < m_panelMaxWidth) {
			m_panelWidth += m_animationSpeed;

			// Update changes
			m_rt.localScale = new Vector3 (m_panelWidth, 1f, 1f);
		}

		// Check the timer to close the panel
		if (m_timer > m_timerLimit)
			m_activate = false;
	}


	private void desableDescription() {

		// Change the width of the panel
		if (m_panelWidth > 0f) {
			m_panelWidth -= m_animationSpeed;

			// Update changes
			m_rt.localScale = new Vector3 (m_panelWidth, 1f, 1f);
		}

	}
}
