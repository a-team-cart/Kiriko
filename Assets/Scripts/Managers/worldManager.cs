using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class worldManager : MonoBehaviour {

	// public variables --------------------
	public GameObject m_InputManager;
	public GameObject m_MainCamera;
	public Vector3 m_VRplayerPos;
	public GameObject[] m_dynamicObjects;
	public bool m_playerInSpace;

	// private variables -------------------
	private float m_playerBoundaries;

	//debug variables --- Use this as temporary variables
	
	//gravity
	public float gravityShift = 0f;

	//instantiating stuff
	public GameObject m_spawnPosition;
	public int m_spawnRange = 50;
	public GameObject[] mineral;
	public GameObject[] mineralFractured;
	private bool[] objectIsDestroyed;
	public int m_maxNumberOfObjects = 100;
	public int m_objectIndex = 0;
	public List<GameObject> m_instancedObjects = new List<GameObject>();
	public float thrust = 0.0001f;

	//chaning object porperties
	public float m_objectSize;
	public Material[] m_objectShader;
	public int m_shaderIndex;
	private Vector3[] randomRotation;

	//lights
	public GameObject[] m_allOfTheLights;
	Light[] m_allOfTheLightsLightComponent;
	public float m_lightBrightness;
	private float m_lightHue;
	private float m_lightSaturation;
	private float m_lightValue;
	public float m_lightControlHue;
	public float m_lightControlSaturation;
	public float m_lightControlValue;
	public Color m_lightColor;

	//post processing stack
	private PostProcessVolume volume;
	Vignette m_vignette;
	ColorGrading m_saturation;
	ChromaticAberration m_chromatic;
	public float m_vignetteValue;
	public float m_saturationValue;
	public float m_chromaticValue;


	//timescale
	public float timeModifier;
	public float deltaTime;
	public float fps;

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
		//fps counter
		fpsCounter();

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

		//post processing stack
		changePostProcessing();

		//midi
		attachToMidi();

		
	}


	// -------------------------------------
	// Methods
	// -------------------------------------

	private void init(){
		//store original location (for relocate)
		m_originalPosition = m_VRplayerPos;
		//set object size to 1
		m_objectSize = 30;

		objectIsDestroyed = new bool[m_maxNumberOfObjects];

		randomRotation = new Vector3[m_maxNumberOfObjects];

		volume = m_MainCamera.GetComponent<PostProcessVolume>();
		volume.profile.TryGetSettings(out m_vignette);
		volume.profile.TryGetSettings(out m_saturation);
		volume.profile.TryGetSettings(out m_chromatic);
	}

	//changes the pst processing stack at runtime
	private void changePostProcessing() {
		 // later in this class during handling and changing
		m_vignette.enabled.value = true;
		m_vignetteValue = Mathf.Clamp(m_vignetteValue, 0.0f, 1.0f);
		m_vignette.intensity.value = m_vignetteValue;
		
		m_chromatic.enabled.value = true;
		m_chromaticValue = Mathf.Clamp(m_chromaticValue, 0.0f, 30.0f);
		m_chromatic.intensity.value = m_chromaticValue;
		
		m_saturation.enabled.value = true;
		m_saturationValue = Mathf.Clamp(m_saturationValue, -200.0f, 200.0f);
		m_saturation.saturation.value = m_saturationValue;
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
			// Vector3 randomPos = (Vector3)Random.insideUnitCircle * m_spawnRange; 	
			// randomPos += m_spawnPosition.transform.position;
			float xRange = Random.Range(-m_spawnRange,m_spawnRange);
			float yRange = Random.Range(-m_spawnRange,m_spawnRange);
			float zRange = Random.Range(-m_spawnRange,m_spawnRange);
			randomRotation[i] = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
			// Debug.Log(randomRotation[i]);
			GameObject obj = (GameObject)Instantiate(mineral[Random.Range (0,mineral.Length)], new Vector3(xRange,yRange,zRange), Random.rotation);
			obj.GetComponent<Renderer>().material = m_objectShader[Random.Range (0,m_objectShader.Length)];
			// obj.GetComponent<Rigidbody>().AddTorque(randomRotation[i] * thrust);
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
				// Vector3 randomPos = (Vector3)Random.insideUnitCircle * m_spawnRange; 
				// m_instancedObjects[i].transform.position = randomPos;
				m_instancedObjects[j].SetActive(true); 
				m_instancedObjects[j].GetComponent<Rigidbody>().AddTorque(randomRotation[j] * thrust);
			}
		}

		for(int i = m_objectIndex; i < m_maxNumberOfObjects;i++){
			// objectIsDestroyed[i] = false;
			m_instancedObjects[i].SetActive(false);
			// m_instancedObjects[i].transform.localScale = new Vector3(Random.Range(0.0f, 10.0f),Random.Range(0.0f, 10.0f),Random.Range(0.0f, 10.0f));
			if(objectIsDestroyed[i] == false){
				objectIsDestroyed[i] = true;
				Vector3 destroyedObjectPosition = m_instancedObjects[i].transform.position;
				if(fps > 45){
				GameObject brokenObj = (GameObject)Instantiate(mineralFractured[Random.Range (0,mineralFractured.Length)], new Vector3(m_instancedObjects[i].transform.position.x,m_instancedObjects[i].transform.position.y,m_instancedObjects[i].transform.position.z), m_instancedObjects[i].transform.rotation);
				brokenObj.transform.localScale =  m_instancedObjects[i].transform.localScale/15;
				// brokenObj.GetComponent<Renderer>().material = m_objectShader[Random.Range (0,m_objectShader.Length)];
				Renderer[] children = brokenObj.GetComponentsInChildren<Renderer> ();
				foreach(Renderer rend in children){
					rend.material = m_objectShader[m_shaderIndex];
				}
				Destroy(brokenObj, 10.0f);
				}
				
			}
		}
	}

	//change object properties
	private void changeObjectProperties(){
		//constrain the object size value
		m_objectSize = Mathf.Clamp(m_objectSize, 30.0f,200.0f);

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
		m_lightControlHue = Mathf.Clamp(m_lightControlHue, 0.0f,1.0f);
		m_lightControlSaturation = Mathf.Clamp(m_lightControlSaturation, 0.0f,1.0f);
		m_lightControlValue = Mathf.Clamp(m_lightControlValue, 0.0f,1.0f);

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

	private void attachToMidi(){
		//gravity
		// gravityShift = 0f;
		// m_objectIndex;

		// //chaning object porperties
		// m_objectSize;
		// m_objectShader;

		// //lights
		// m_allOfTheLights;
		// m_lightBrightness;
		// m_lightHue;
		// m_lightSaturation;
		// m_lightValue;
		// m_lightControlHue;
		// m_lightControlSaturation;
		// m_lightControlValue;
		// m_lightColor;

		// //timescale
		// timeModifier;

		//remapped values for midi between 0 & 1
		
		//-----object 
		float m_midiObjectIndex = m_InputManager.GetComponent<inputManager>().m_objectSpawn;
		float m_midiObjectScale = m_InputManager.GetComponent<inputManager>().m_objectScale;
		float m_midiObjectGravity = m_InputManager.GetComponent<inputManager>().m_objectGravity;
		float m_midiObjectShader = m_InputManager.GetComponent<inputManager>().m_objectMaterial;
		float m_midiObjectRotation = m_InputManager.GetComponent<inputManager>().m_objectRotation;

		//----light
		float m_midiLightIntensity = m_InputManager.GetComponent<inputManager>().m_lightIntensity;
		float m_midiLightHue = m_InputManager.GetComponent<inputManager>().m_lightHue;
		float m_midiLightSaturation = m_InputManager.GetComponent<inputManager>().m_lightSaturation;		
		float m_midiLightValue = m_InputManager.GetComponent<inputManager>().m_lightValue;

		//----postprocessing
		float m_midiPsaturation = m_InputManager.GetComponent<inputManager>().m_PPsaturation;
		float m_midiPchromatic = m_InputManager.GetComponent<inputManager>().m_PPchromaticAberration;		
		float m_midiPvignette = m_InputManager.GetComponent<inputManager>().m_PPvignette;
		// float m_midi = m_InputManager.GetComponent<inputManager>().m_objectGravity;



		//------------------VALUE SCALING
		m_objectIndex=scaleAndAttachRounded(m_midiObjectIndex,m_objectIndex,0, m_maxNumberOfObjects);
		m_shaderIndex=scaleAndAttachRounded(m_midiObjectShader,m_shaderIndex,0,m_objectShader.Length);
		m_objectSize=scaleAndAttach(m_midiObjectScale,m_objectSize,30.0f,200.0f);
		gravityShift=scaleAndAttach(m_midiObjectGravity,gravityShift,-1.0f,1.0f);
		thrust=scaleAndAttach(m_midiObjectRotation,thrust,-0.0001f,0.0001f);

		m_lightBrightness=scaleAndAttach(m_midiLightIntensity,m_lightBrightness,0.0f,100.0f);
		m_lightControlHue=scaleAndAttach(m_midiLightHue,m_lightControlHue,0.0f,1.0f);
		m_lightControlSaturation=scaleAndAttach(m_midiLightSaturation,m_lightControlSaturation,0.0f,1.0f);
		m_lightControlValue=scaleAndAttach(m_midiLightValue,m_lightControlValue,0.0f,1.0f);

		m_saturationValue=scaleAndAttach(m_midiPsaturation,m_saturationValue,-200.0f,200.0f);
		m_chromaticValue=scaleAndAttach(m_midiPchromatic,m_chromaticValue,0.0f,30.0f);
		m_vignetteValue=scaleAndAttach(m_midiPvignette,m_vignetteValue,0.0f,1.0f);

		// scaleAndAttach();
		// scaleAndAttach();
		// scaleAndAttach();
		// scaleAndAttach();

		// m_midiObjectIndex = scale(0.0f,1.0f,0.0f,100.0f,m_midiObjectIndex);
		// int roundedObjectIndex = Mathf.RoundToInt(m_midiObjectIndex);
		// m_objectIndex = roundedObjectIndex;

		//-----object scale
		// m_midiObjectScale = scale(0.0f,1.0f,0.0f,100.0f,m_midiObjectScale);
		// m_objectSize = m_midiObjectScale;
		// Debug.Log(m_objectIndex);

		//-----object gravity
		// m_midiObjectGravity = scale(0.0f,1.0f,-1.0f,1.0f,m_midiObjectGravity);
		// gravityShift = m_midiObjectGravity;
		// Debug.Log(m_objectIndex);




	}

	private float scaleAndAttach(float midiObject,float worldObject,float scaleMin, float scaleMax){
		midiObject = scale(0.0f,1.0f,scaleMin,scaleMax,midiObject);
		worldObject = midiObject;
		return worldObject;
		// Debug.Log(midiObject + "is :" + worldObject);
	}

	private int scaleAndAttachRounded(float midiObject,int worldObject,int scaleMin, int scaleMax){
		midiObject = scale(0.0f,1.0f,scaleMin,scaleMax,midiObject);
		int roundedObject = Mathf.RoundToInt(midiObject);
		worldObject = roundedObject;
		return worldObject;
		// return;
		// Debug.Log(midiObject + "is :" + roundedObject);
	}

	float scale(float OldMin, float OldMax, float NewMin, float NewMax, float OldValue){
	
		float OldRange = (OldMax - OldMin);
		float NewRange = (NewMax - NewMin);
		float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;
	
		return(NewValue);
	}

	private void fpsCounter(){
		deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
		fps = 1.0f / deltaTime;
		// Debug.Log("FPS" + fps);
	}

}
