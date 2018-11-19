using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectDescriptionController : MonoBehaviour {

	// public variables --------------------
	public RectTransform m_text;
	public RectTransform m_line;
	[Space(10)]
	public float m_animationSpeed = 15f;
	public float m_textMaxWidth = 160f;
	public float m_lineMaxWidth = 235f;
	public bool m_activate;

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
		m_line.sizeDelta = new Vector2 (m_lineWidth, 1);
		
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

		// Change the width of the line
		if (m_lineWidth < m_lineMaxWidth) {
			m_lineWidth += m_animationSpeed;
			
			// Update changes
			m_line.sizeDelta = new Vector2 (m_lineWidth, 1);
		}

		// Change the width of the text
		if (m_textWidth < m_textMaxWidth) {
			m_textWidth += m_animationSpeed;

			// Update changes
			m_text.sizeDelta = new Vector2 (m_textWidth, 76);
		}

	}


	private void desableDescription() {

		// Change the width of the line
		if (m_lineWidth > 0f) {
			m_lineWidth -= m_animationSpeed;
			
			// Update changes
			m_line.sizeDelta = new Vector2 (m_lineWidth, 1);
		}

		// Change the width of the text
		if (m_textWidth > 0f) {
			m_textWidth -= m_animationSpeed;

			// Update changes
			m_text.sizeDelta = new Vector2 (m_textWidth, 76);
		}

	}


}
