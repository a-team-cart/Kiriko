using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayManager : MonoBehaviour {

	// -------------------------------------
	// Use this for initialization
	// -------------------------------------
	void Start () {
		// Print number of display found by Unity
		Debug.Log("displays connected: " + Display.displays.Length);

        // Display.displays[0] is the primary, default display and is always ON.
        // Check if additional displays are available and activate each.
        //if (Display.displays.Length > 1)
        //    Display.displays[1].Activate();
		
		// Quick turn around to solve the problem
		for(int i = 0; i < Display.displays.Length; i++) {
			Display.displays[i].Activate(1920, 1080, 60);
		}
	}
}
