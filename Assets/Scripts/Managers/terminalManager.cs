using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class terminalManager : MonoBehaviour {
	// public variables --------------------
	public GameObject m_InputManager;
	[Header("Sliders Value")]
	public GameObject[] m_effects;


	// private variables -------------------


	// -------------------------------------
	// Use this for initialization
	// -------------------------------------
	void Start () {
		
	}
	
	// -------------------------------------
	// Update is called once per frame
	// -------------------------------------
	void Update () {
		// Update values of sliders
		catchSliderValues();		

		
	}

	// -------------------------------------
	// Methods
	// -------------------------------------
	private void catchSliderValues() {
		// Screen the values from input manager
		m_effects[0].GetComponent<Slider>().value = m_InputManager.GetComponent<inputManager>().m_saturation;
		m_effects[1].GetComponent<Slider>().value = m_InputManager.GetComponent<inputManager>().m_gravity;
		m_effects[2].GetComponent<Slider>().value = m_InputManager.GetComponent<inputManager>().m_timeSpeed;
		m_effects[3].GetComponent<Slider>().value = m_InputManager.GetComponent<inputManager>().m_lightIntensity;
		m_effects[4].GetComponent<Slider>().value = m_InputManager.GetComponent<inputManager>().m_soundPitch;
		m_effects[5].GetComponent<Slider>().value = m_InputManager.GetComponent<inputManager>().m_normalIntensity;
	}


	private void showDescriptions() {
		


	}
}
