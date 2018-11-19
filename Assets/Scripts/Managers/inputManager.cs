using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class inputManager : MonoBehaviour
{

    // public variables --------------------
    public float m_saturation;                                  // Saturation of colors in the scene
    public float m_gravity;                                     // Gravity scale in the scene
    public float m_timeSpeed;                                   // Time speed for motion in the scene
    public bool m_lightState;                                   // Lights on or off
    public float m_lightIntensity;                              // Lights intensity in the scene
    public float m_soundPitch;                                  // Global sound pitch of a soudscape
    public int[] m_soundScapeIndex;                             // Soundscape index 
    public float m_normalIntensity;                             // Normal intensity of textures in the scene
    public int[] m_spawnObjectIndex;                            // Number of objects spawn in the scene
    public float m_noiseIntensity;                              // Noise intensity for the volumetric lighting
    public float m_chromaticAberration;                         // Intensity of cromatic aberratin (PPS)
    public float m_stormState;                                  // Intensity of the weather storm (rain - snow)

    // private variables -------------------


    // -------------------------------------
    // Use this for initialization
    // -------------------------------------
    void Start()
    {

    }


    // -------------------------------------
    // Update is called once per frame
    // -------------------------------------
    void Update()
    {

        // Listen for new inputs
        fetchData();

    }


    // -------------------------------------
    // Methods
    // -------------------------------------
    // Fetching data from the inputs
    private void fetchData()
    {
        m_saturation = MidiMaster.GetKnob(14);
		m_gravity = MidiMaster.GetKnob(15);
		m_timeSpeed = MidiMaster.GetKnob(16);
		m_lightIntensity = MidiMaster.GetKnob(3);
		m_soundPitch = MidiMaster.GetKnob(4);
		m_normalIntensity = MidiMaster.GetKnob(5);
    }


}