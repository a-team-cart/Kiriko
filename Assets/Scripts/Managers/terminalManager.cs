using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class terminalManager : MonoBehaviour {
	// public variables --------------------
	public GameObject m_InputManager;
	[Header("Sliders Value")]
	public GameObject[] m_objectEffects;
	public GameObject[] m_lightEffects;
	public GameObject[] m_soundEffects;
	public GameObject[] m_ppEffects;


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
		// Object Effects
		m_objectEffects[0].GetComponent<Slider>().value = m_InputManager.GetComponent<inputManager>().m_objectSpawn;
		m_objectEffects[1].GetComponent<Slider>().value = m_InputManager.GetComponent<inputManager>().m_objectScale;
		m_objectEffects[2].GetComponent<Slider>().value = m_InputManager.GetComponent<inputManager>().m_objectRotation;
		m_objectEffects[3].GetComponent<Slider>().value = m_InputManager.GetComponent<inputManager>().m_objectGravity;
		m_objectEffects[4].GetComponent<Slider>().value = m_InputManager.GetComponent<inputManager>().m_objectMaterial;

		// Light Effects
		m_lightEffects[0].GetComponent<Slider>().value = m_InputManager.GetComponent<inputManager>().m_lightIntensity;
		m_lightEffects[1].GetComponent<Slider>().value = m_InputManager.GetComponent<inputManager>().m_lightHue;
		m_lightEffects[2].GetComponent<Slider>().value = m_InputManager.GetComponent<inputManager>().m_lightSaturation;
		m_lightEffects[3].GetComponent<Slider>().value = m_InputManager.GetComponent<inputManager>().m_lightValue;

		// Sound Effects
		m_soundEffects[0].GetComponent<Slider>().value = m_InputManager.GetComponent<inputManager>().m_soundPitch;
		m_soundEffects[1].GetComponent<Slider>().value = m_InputManager.GetComponent<inputManager>().m_soundTimescale;
		m_soundEffects[2].GetComponent<Slider>().value = m_InputManager.GetComponent<inputManager>().m_soundReverbDecay;
		m_soundEffects[3].GetComponent<Slider>().value = m_InputManager.GetComponent<inputManager>().m_soundFeedback;
		m_soundEffects[4].GetComponent<Slider>().value = m_InputManager.GetComponent<inputManager>().m_soundFilter;
		m_soundEffects[5].GetComponent<Slider>().value = m_InputManager.GetComponent<inputManager>().m_soundSlide;

		// Post Processing Effects
		m_ppEffects[0].GetComponent<Slider>().value = m_InputManager.GetComponent<inputManager>().m_PPsaturation;
		m_ppEffects[1].GetComponent<Slider>().value = m_InputManager.GetComponent<inputManager>().m_PPchromaticAberration;
		m_ppEffects[2].GetComponent<Slider>().value = m_InputManager.GetComponent<inputManager>().m_PPvignette;
	}


	private void showDescriptions() {
		


	}
}
