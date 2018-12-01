using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class numberController : MonoBehaviour {

	// public variables --------------------
	public bool m_randomNumber = false;
	public bool m_randomCounter = false;
	public bool m_sliderNumber = false;
	public bool m_knobNumber = false;
	[Header("Variables for sliders and knobs")]
	public GameObject m_description;
	public string m_effectTitle;



	// private variables -------------------
	private Text m_textContainer;
	private float m_timer;
	private float m_counter = 100f;


	// -------------------------------------
	// Use this for initialization
	// -------------------------------------
	void Start () {
		// Get the Text component
		m_textContainer = gameObject.GetComponent<Text>();
		
	}
	
	// -------------------------------------
	// Update is called once per frame
	// -------------------------------------
	void Update () {
		if (m_randomNumber)
			numberGenerator();
		
		if (m_sliderNumber)
			sliderGenerator();

		if (m_knobNumber)
			knobGenerator();

		if (m_randomCounter)
			counterGenerator();
	}

	// -------------------------------------
	// Methods
	// -------------------------------------
	// Values for top left numbers ---------------------------------------------------
	private void numberGenerator() {
			// Fetch some random values
			float x = Random.Range(100, 999);
			float y = Random.Range(1000, 9999);
			float z = Random.Range(100,999);

			// Replace the text container
			m_textContainer.text = x.ToString() + "." + y.ToString() + "." + z.ToString();
	}

	// Values for sliders ------------------------------------------------------------
	private void sliderGenerator() {
		// Fetch some random values
		float x = Random.Range(100, 999);
		float y = Random.Range(1000, 9999);

		float h = Random.Range(100, 999);
		float k = Random.Range(1000, 9999);

		// Replace the text container and only when the slider is activated
		if (m_description.GetComponent<effectDescriptionController>().m_valueIsChanging)
			m_textContainer.text = m_effectTitle + "\n" + x.ToString() + "." + y.ToString() + "\n" + h.ToString() + "." + k.ToString();
	}

	// Values for knobs ---------------------------------------------------------------
	private void knobGenerator() {
		// Fetch some random values
		float x = Random.Range(100, 999);
		float y = Random.Range(1000, 9999);
		float z = Random.Range(1000,9999);

		float h = Random.Range(100, 999);
		float k = Random.Range(1000, 9999);
		float l = Random.Range(1000,9999);

		// Replace the text container and only when the slider is activated
		if (m_description.GetComponent<effectDescriptionController>().m_valueIsChanging)
			m_textContainer.text = m_effectTitle + "\n" + x.ToString() + "." + y.ToString() + "." + z.ToString() + "\n" + h.ToString() + "." + k.ToString() + "." + l.ToString();
	}

	// Values for counter -------------------------------------------------------------
	private void counterGenerator() {
		// Get the time value
		if (m_timer < 5f) {
			m_timer += Time.deltaTime;
		} else {
			m_timer = 0f;
			m_counter ++;
		}
		
		// Print the counter
		m_textContainer.text = m_counter.ToString();
	}

}
