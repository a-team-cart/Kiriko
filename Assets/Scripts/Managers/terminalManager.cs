using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class terminalManager : MonoBehaviour {
	// public variables --------------------
	public GameObject m_InputManager;
	[Header("Sliders Value")]
	public Slider[] m_objectEffects;
	public Slider[] m_lightEffects;
	public Slider[] m_soundEffects;
	public Slider[] m_ppEffects;
	[Header("Effect Descriptions")]
	public GameObject[] m_objectDescriptions;
	public GameObject[] m_lightDescriptions;
	public GameObject[] m_soundDescriptions;
	public GameObject[] m_ppDescriptions;
	[Header("Two main panels")]
	public GameObject m_knobPanel;
	public GameObject m_sliderPanel;

	// private variables -------------------
	private float[] m_objectValues;
	private float[] m_lightValues;
	private float[] m_soundValues;
	private float[] m_ppValues;
	private bool m_knobActivated = false;
	private bool m_sliderActivated = false;



	// -------------------------------------
	// Use this for initialization
	// -------------------------------------
	void Start () {
		// Give the value 0 for all object effect
		m_objectValues = new float[m_objectEffects.Length];
		for (int i = 0; i < m_objectValues.Length; i++) {
			m_objectValues[i] = 0f;
		}
		// Give the value 0 for all light effect
		m_lightValues = new float[m_lightEffects.Length];
		for (int i = 0; i < m_lightValues.Length; i++) {
			m_lightValues[i] = 0f;
		}
		// Give the value 0 for all sound effect
		m_soundValues = new float[m_soundEffects.Length];
		for (int i = 0; i < m_soundValues.Length; i++) {
			m_soundValues[i] = 0f;
		}
		// Give the value 0 for all pp effect
		m_ppValues = new float[m_ppEffects.Length];
		for (int i = 0; i < m_ppValues.Length; i++) {
			m_ppValues[i] = 0f;
		}
	}

	
	// -------------------------------------
	// Update is called once per frame
	// -------------------------------------
	void Update () {
		// Update values of sliders
		catchSliderValues();	

		// Check Activity
		listen();

		// Activate a panel on user's inputs
		if (m_knobActivated) { 
			activateKnobs();
			m_knobActivated = false;
		}

		if (m_sliderActivated) {
			activateSliders();
			m_sliderActivated = false;
		}


		
	}

	// -------------------------------------
	// Methods
	// -------------------------------------
	// Function to catch all the values recorded by the user ---------------------------------------------------
	private void catchSliderValues() {
		// Screen the values from input manager
		// Object Effects
		/*
		m_objectEffects[0].value = m_InputManager.GetComponent<inputManager>().m_objectSpawn;
		m_objectEffects[1].value = m_InputManager.GetComponent<inputManager>().m_objectScale;
		m_objectEffects[2].value = m_InputManager.GetComponent<inputManager>().m_objectRotation;
		m_objectEffects[3].value = m_InputManager.GetComponent<inputManager>().m_objectGravity;
		m_objectEffects[4].value = m_InputManager.GetComponent<inputManager>().m_objectMaterial;

		// Light Effects
		m_lightEffects[0].value = m_InputManager.GetComponent<inputManager>().m_lightIntensity;
		m_lightEffects[1].value = m_InputManager.GetComponent<inputManager>().m_lightHue;
		m_lightEffects[2].value = m_InputManager.GetComponent<inputManager>().m_lightSaturation;
		m_lightEffects[3].value = m_InputManager.GetComponent<inputManager>().m_lightValue;

		// Sound Effects
		m_soundEffects[0].value = m_InputManager.GetComponent<inputManager>().m_soundPitch;
		m_soundEffects[1].value = m_InputManager.GetComponent<inputManager>().m_soundTimescale;
		m_soundEffects[2].value = m_InputManager.GetComponent<inputManager>().m_soundReverbDecay;
		m_soundEffects[3].value = m_InputManager.GetComponent<inputManager>().m_soundFeedback;
		m_soundEffects[4].value = m_InputManager.GetComponent<inputManager>().m_soundFilter;
		m_soundEffects[5].value = m_InputManager.GetComponent<inputManager>().m_soundSlide;

		// Post Processing Effects
		m_ppEffects[0].value = m_InputManager.GetComponent<inputManager>().m_PPsaturation;
		m_ppEffects[1].value = m_InputManager.GetComponent<inputManager>().m_PPchromaticAberration;
		m_ppEffects[2].value = m_InputManager.GetComponent<inputManager>().m_PPvignette;
		*/
	}


	// Function to look if value is been changing by the user ------------------------------------------------
	private void listen() {
		// Check if the value change for all object effects
		for(int i = 0; i < m_objectEffects.Length; i++) {
			if(m_objectEffects[i].value != m_objectValues[i]) {
				// Activate the corrrect description and set the timer
				m_objectDescriptions[i].GetComponent<effectDescriptionController>().m_activate = true;
				m_objectDescriptions[i].GetComponent<effectDescriptionController>().m_timer = 0.0f;
				// Show the correct panel
				m_knobActivated = true;
				// Record the new value
				m_objectValues[i] = m_objectEffects[i].value;
			}
		}

		// Check if the value change for all light effects
		for(int i = 0; i < m_lightEffects.Length; i++) {
			if(m_lightEffects[i].value != m_lightValues[i]) {
				// Activate the corrrect description and set the timer
				m_lightDescriptions[i].GetComponent<effectDescriptionController>().m_activate = true;
				m_lightDescriptions[i].GetComponent<effectDescriptionController>().m_timer = 0.0f;
				// Show the correct panel
				m_knobActivated = true;
				// Record the new value
				m_lightValues[i] = m_lightEffects[i].value;
			}
		}

		// Check if the value change for all object effects
		for(int i = 0; i < m_soundEffects.Length; i++) {
			if(m_soundEffects[i].value != m_soundValues[i]) {
				// Activate the corrrect description and set the timer
				m_soundDescriptions[i].GetComponent<effectDescriptionController>().m_activate = true;
				m_soundDescriptions[i].GetComponent<effectDescriptionController>().m_timer = 0.0f;
				// Show the correct panel
				m_sliderActivated = true;
				// Record the new value
				m_soundValues[i] = m_soundEffects[i].value;
			}
		}

		// Check if the value change for all object effects
		for(int i = 0; i < m_ppEffects.Length; i++) {
			if(m_ppEffects[i].value != m_ppValues[i]) {
				// Activate the corrrect description and set the timer
				m_ppDescriptions[i].GetComponent<effectDescriptionController>().m_activate = true;
				m_ppDescriptions[i].GetComponent<effectDescriptionController>().m_timer = 0.0f;
				// Show the correct panel
				m_sliderActivated = true;
				// Record the new value
				m_ppValues[i] = m_ppEffects[i].value;
			}
		}
	}
	

	// Function to activate the knob panel ------------------------------------------------------------------
	private void activateKnobs() {
		// Activate animation and set the timer to 0f
		m_knobPanel.GetComponent<panelController>().m_activate = true;
		m_knobPanel.GetComponent<panelController>().m_timer = 0f;
	}

	// Function to activate the slider panel ----------------------------------------------------------------
	private void activateSliders() {
		// Activate animation and set the timer to 0f
		m_sliderPanel.GetComponent<panelController>().m_activate = true;
		m_sliderPanel.GetComponent<panelController>().m_timer = 0f;
	}
}
