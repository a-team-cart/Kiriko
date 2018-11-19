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
		m_effects[0].GetComponent<Slider>().value = m_InputManager.GetComponent<inputManager>().m_objectSpawn;
		m_effects[1].GetComponent<Slider>().value = m_InputManager.GetComponent<inputManager>().m_objectScale;
		m_effects[2].GetComponent<Slider>().value = m_InputManager.GetComponent<inputManager>().m_objectRotation;
		m_effects[3].GetComponent<Slider>().value = m_InputManager.GetComponent<inputManager>().m_objectMaterial;
		m_effects[4].GetComponent<Slider>().value = m_InputManager.GetComponent<inputManager>().m_objectGravity;
		m_effects[5].GetComponent<Slider>().value = m_InputManager.GetComponent<inputManager>().m_lightSaturation;
	}


	private void showDescriptions() {
		


	}
}
