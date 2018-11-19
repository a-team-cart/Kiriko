﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldManager : MonoBehaviour {

	// public variables --------------------
	public Vector3 m_VRplayerPos;
	public GameObject[] m_dynamicObjects;
	public bool m_playerInSpace;

	// private variables -------------------
	private float m_playerBoundaries;

	//debug variables --- Use this as temporary variables
	
	//gravity
	public float gravityShift = 0f;

	//instantiating stuff
	public GameObject cubeBody;
	public GameObject cubeBodyFractured;
	private bool[] objectIsDestroyed;
	public int m_maxNumberOfObjects = 20;
	public int m_objectIndex;
	public List<GameObject> m_instancedObjects = new List<GameObject>();

	//chaning object porperties
	public float m_objectSize;
	public Material m_objectShader;

	//lights
	public GameObject[] m_allOfTheLights;
	Light[] m_allOfTheLightsLightComponent;
	public float m_lightBrightness;
	public float m_lightHue;
	public float m_lightSaturation;
	public float m_lightValue;
	public float m_lightControlHue;
	public float m_lightControlSaturation;
	public float m_lightControlValue;
	public Color m_lightColor;

	//timescale
	public float timeModifier;

	//player relocate
	public Vector3 m_originalPosition;

	// -------------------------------------
	// Use this for fetching components
	// -------------------------------------
	void Awake () {
		//fetch all lights and store them
		fetchAllLights();
		
	}
	
	// -------------------------------------
	// Use this for initialization
	// -------------------------------------
	void Start () {

		//initialize function
		init();
		//instantiate
		instantiateObjects();
		
	}
	

	// -------------------------------------
	// Update is called once per frame
	// -------------------------------------
	void Update () {

		//ChangeGravity
		changeGravity();

		//changetime
		changeTimeValue();

		//resize the list
		Resize();

		//change properties
		changeObjectProperties();

		//change light properties
		changeLightProperties();

		
	}


	// -------------------------------------
	// Methods
	// -------------------------------------

	private void init(){
		//store original location (for relocate)
		m_originalPosition = m_VRplayerPos;
		//set object size to 1
		m_objectSize = 1;

		objectIsDestroyed = new bool[m_maxNumberOfObjects];
	}

	// Function to change the weather
	private void changeWeather() {

	}

	// Function to change the gravity 
	// ------ make sure to add rigibody everywhere
  	private void changeGravity() {
		  gravityShift = Mathf.Clamp(gravityShift, -1.0f, 1.0f);
		  Physics.gravity = new Vector3(0,gravityShift,0);

	}

	// Function to change the time of motion
	private void changeTimeValue() {
		timeModifier = Mathf.Clamp(timeModifier, 1.0f,20.0f);
		Time.timeScale = timeModifier;
	}

	// Function to initiate new dynamic objects
	private void instantiateObjects() {
			for (int i = 0; i < m_maxNumberOfObjects; i++) {
			GameObject obj = (GameObject)Instantiate(cubeBody);
			obj.SetActive(false); 
			m_instancedObjects.Add(obj);
		}
	}

	//list function that adds or removes object
	private void Resize() {
		//constain the list to the max number of object
		m_objectIndex = Mathf.Clamp(m_objectIndex, 0, m_maxNumberOfObjects);
		int currentObjectIndex = m_objectIndex;

		for (int i = 0; i < m_maxNumberOfObjects; i++) {
			for(int j = 0; j < m_objectIndex; j++){
				objectIsDestroyed[j] = false;
				m_instancedObjects[j].SetActive(true); 
			}
		}

		for(int i = m_objectIndex; i < m_maxNumberOfObjects;i++){
			// objectIsDestroyed[i] = false;
			m_instancedObjects[i].SetActive(false);
			m_instancedObjects[i].transform.localScale = new Vector3(Random.Range(0.0f, 10.0f),Random.Range(0.0f, 10.0f),Random.Range(0.0f, 10.0f));
			if(objectIsDestroyed[i] == false){
				objectIsDestroyed[i] = true;
				Vector3 destroyedObjectPosition = m_instancedObjects[i].transform.position;
				GameObject brokenObj = (GameObject)Instantiate(cubeBodyFractured, new Vector3(m_instancedObjects[i].transform.position.x,m_instancedObjects[i].transform.position.y,m_instancedObjects[i].transform.position.z), Quaternion.identity);
				Destroy(brokenObj, 2.0f);
				
			}
		}
	}

	//change object properties
	private void changeObjectProperties(){
		//constrain the object size value
		m_objectSize = Mathf.Clamp(m_objectSize, 0.0f,100.0f);

		for(int i = 0; i < m_instancedObjects.Count; i++){
			m_instancedObjects[i].transform.localScale = new Vector3(m_objectSize,m_objectSize,m_objectSize);
		}

	}

	//fetch all lights in scene
	private void fetchAllLights(){
		m_allOfTheLights = GameObject.FindGameObjectsWithTag("Light");
		m_allOfTheLightsLightComponent = new Light[m_allOfTheLights.Length];

		for(int i = 0; i < m_allOfTheLights.Length; i ++){
			m_allOfTheLightsLightComponent[i] = m_allOfTheLights[i].GetComponent<Light>();
			// Debug.Log(m_allOfTheLights);
		}

		
	}

	//change light properties
	private void changeLightProperties(){
		//constrain the light intensity
		m_lightBrightness = Mathf.Clamp(m_lightBrightness, 0.0f,100.0f);
		m_lightControlHue = Mathf.Clamp(m_lightControlHue, 0.0f,255.0f);
		m_lightControlSaturation = Mathf.Clamp(m_lightControlSaturation, 0.0f,255.0f);
		m_lightControlValue = Mathf.Clamp(m_lightControlValue, 0.0f,255.0f);

		for(int i = 0; i < m_allOfTheLightsLightComponent.Length; i++){
			Color.RGBToHSV(m_allOfTheLightsLightComponent[i].color, out m_lightHue, out m_lightSaturation, out m_lightValue);
			m_allOfTheLightsLightComponent[i].color = new Color(m_lightControlHue,m_lightControlSaturation,m_lightControlValue);
			m_allOfTheLightsLightComponent[i].intensity = m_lightBrightness;
		}
	}

	//return a polled game objects
	public GameObject GetPooledObject() {
	//1
	for (int i = 0; i < m_instancedObjects.Count; i++) {
	//2
		if (!m_instancedObjects[i].activeInHierarchy) {
		return m_instancedObjects[i];
		}
	}
	//3   
	return null;
	}

	// Function to relocate player /reset to its original location when it started
	private void relocatePlayer() {
		if(Input.GetKeyDown("space")){
			m_VRplayerPos = m_originalPosition;
		}
	}


}
