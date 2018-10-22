using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour {
	
	// public variables --------------------

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
		
	}

	// -------------------------------------
	// Methods
	// -------------------------------------
	// Function to quit the application
	private void quit() {
		Application.Quit();
	}

	// Funtion to restart application
	private void restart() {
		SceneManager.LoadScene(0);
	}


}
