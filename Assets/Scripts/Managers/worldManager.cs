using System.Collections;
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
	public int maxNumberOfObjects = 20;
	public int objectIndex;
	public Rigidbody[] instantiatedObjects;
	public List<GameObject> instancedObjects = new List<GameObject>();

	//timescale
	public float timeModifier;

	//player relocate
	public Vector3 originalPosition;
	
	// -------------------------------------
	// Use this for initialization
	// -------------------------------------
	void Start () {

		for (int i = 0; i < maxNumberOfObjects; i++) {
		GameObject obj = (GameObject)Instantiate(cubeBody);
		obj.SetActive(false); 
		instancedObjects.Add(obj);
		}

		//store original location (for relocate)
		originalPosition = m_VRplayerPos;

		//instantiate
		// instantiateObjects();
		
	}
	

	// -------------------------------------
	// Update is called once per frame
	// -------------------------------------
	void Update () {

		//ChangeGravity
		changeGravity();

		//changetime
		changeTimeValue();

		// Resize();

		for (int i = 0; i < maxNumberOfObjects; i++) {
			for(int j = 0; j < objectIndex; j++){
				instancedObjects[j].SetActive(true); 
			}
		}

		for(int i = objectIndex; i < maxNumberOfObjects;i++){
			instancedObjects[i].SetActive(false);
		}
		
	}


	// -------------------------------------
	// Methods
	// -------------------------------------
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
		timeModifier = Mathf.Clamp(timeModifier, 1.0f,10.0f);
		Time.timeScale = Time.timeScale * timeModifier;
	}

	// Function to initiate new dynamic objects
	private void instantiateObjects() {
        for (int i = 0; i < maxNumberOfObjects; i++) 
        {
            // instantiatedObjects[i] = Instantiate(cubeBody, cubeBody.position, Quaternion.identity);
        }
	}

	//list function
	// private void Resize() {
	// 	if (maxNumberOfObjects <= 0) {
	// 		instancedObjects.Clear();
	// 	} else {
	// 		while (instancedObjects.Count > maxNumberOfObjects) {
	// 			instancedObjects.RemoveAt(instancedObjects.Count-1);
	// 			print(instancedObjects.Count);
	// 		}
	// 		while (instancedObjects.Count < maxNumberOfObjects){
	// 			instancedObjects.Add(new InstantiatedObject(50,50,cubeBody.position,cubeBody));
	// 			Instantiate(cubeBody, cubeBody.position, Quaternion.identity);
	// 			print(instancedObjects.Count);
	// 		}
	// 	}
	// }

	public GameObject GetPooledObject() {
	//1
	for (int i = 0; i < instancedObjects.Count; i++) {
	//2
		if (!instancedObjects[i].activeInHierarchy) {
		return instancedObjects[i];
		}
	}
	//3   
	return null;
	}

	// Function to relocate player /reset to its original location when it started
	private void relocatePlayer() {
		if(Input.GetKeyDown("space")){
			m_VRplayerPos = originalPosition;
		}
	}


}
