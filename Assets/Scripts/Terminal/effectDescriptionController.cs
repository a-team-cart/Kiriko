using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectDescriptionController : MonoBehaviour {

	// public variables --------------------
	public RectTransform m_text;
	public RectTransform m_line;
	[Space(10)]
	public float m_animationSpeed = 15f;
	public float m_lineAnimation = 0.5f;
	public float m_textMaxWidth = 160f;
	public float m_lineMaxWidth = 1;
	public bool m_activate;
	[HideInInspector]public bool m_valueIsChanging = false;
	[HideInInspector]public float m_timer;
	public float m_timerLimit = 1f;

	// private variables -------------------
	private float m_textWidth;
	private float m_lineWidth;


	// -------------------------------------
	// Use this for initialization
	// -------------------------------------
	void Start () {
		// Disable descriptions
		m_textWidth = 0f;
		m_lineWidth = 0f;

		// Update changes
		m_text.sizeDelta = new Vector2 (m_textWidth, 76);
		if (m_line != null)
			m_line.localScale = new Vector3 (m_lineWidth, 1, 1);
		
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

		// Change the width of the line
		if (m_line != null && m_lineWidth < m_lineMaxWidth) {
			m_lineWidth += m_lineAnimation;
			
			// Update changes
			m_line.localScale = new Vector3 (m_lineWidth, 1, 1);
		// Make sure it doesn't go over 1
		} else if(m_line != null) {
			m_lineWidth = m_lineMaxWidth;
			m_line.localScale = new Vector3 (m_lineWidth, 1, 1);
		}

		// Change the width of the text
		if (m_textWidth < m_textMaxWidth) {
			m_textWidth += m_animationSpeed;

			// Update changes
			m_text.sizeDelta = new Vector2 (m_textWidth, 76);
		}

		// Check the timer to close the description
		if (m_timer > m_timerLimit)
			m_activate = false;

	}


	private void desableDescription() {

		// Change the width of the line
		if (m_line != null && m_lineWidth > 0f) {
			m_lineWidth -= m_lineAnimation;
			
			// Update changes
			m_line.localScale = new Vector3 (m_lineWidth, 1, 1);
		// Make sure it doesn't go under 0
		} else if(m_line != null) {
			m_lineWidth = 0f;
			m_line.localScale = new Vector3 (m_lineWidth, 1, 1);
		}

		// Change the width of the text
		if (m_textWidth > 0f) {
			m_textWidth -= m_animationSpeed;

			// Update changes
			m_text.sizeDelta = new Vector2 (m_textWidth, 76);
		}

	}


}
