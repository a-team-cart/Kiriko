using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class inputManager : MonoBehaviour
{

    // public variables --------------------
    public float m_PPsaturation;                                // Saturation of colors in the scene
    public float m_PPmotionBlur;                                // Chromatic Aberration effect
    public float m_PPvignette;                                  // Vignette effect value

    public float m_lightIntensity;                              // Lights intensity in the scene
    public float m_lightHue;                                    // Lights hue in the scene
    public float m_lightSaturation;                             // Lights saturation in the scene
    public float m_lightValue;                                  // Lights values in the scene

    public float m_objectScale;                                 // Scale of the objects
    public float m_objectMaterial;                              // Material used on the objects in the scene
    public float m_objectSpawn;                                 // Number of objects in the scene
    public float m_objectRotation;                              // Rotation of objects in the scene
    public float m_objectGravity;                               // Gravity affecting the objects in the scene

    public float m_soundPitch;                                  // Pitch of selected samples
    public float m_soundTimescale;                              // Speed of selected samples
    public float m_soundReverbDecay;                            // Decay time for reverb/delay effects
    public float m_soundFeedback;                               // Intensity of feedback
    public float m_soundFilter;                                 // Filter values for feedback
    public float m_soundSlide;                                  // Slide effect for delay loop

    public float m_resetRowOne;                                 // Reset the row of slider one
    public float m_resetRowTwo;                                 // Reset the row of slider two
    public float m_resetRowThree;                               // Reset the row of slider three
    public float m_resetRowFour;                                // Reset the row of slider four
    public float m_resetRowFive;                                // Reset the row of slider five
    public float m_resetRowSix;                                 // Reset the row of slider six
    public float m_resetRowSeven;                               // Reset the row of slider seven
    public float m_resetRowEight;                               // Reset the row of slider eight
    public float m_resetRowNine;                                // Reset the row of slider nine

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
        // Object Data
        m_objectSpawn = MidiMaster.GetKnob(14);
		m_objectScale = MidiMaster.GetKnob(15);
		m_objectRotation = MidiMaster.GetKnob(16);
		m_objectGravity = MidiMaster.GetKnob(17);
        m_objectMaterial = MidiMaster.GetKnob(18);

        // Light Data
        m_lightIntensity = MidiMaster.GetKnob(19);
		m_lightHue = MidiMaster.GetKnob(20);
		m_lightSaturation = MidiMaster.GetKnob(21);
		m_lightValue = MidiMaster.GetKnob(22);

        // Sound Data
        m_soundPitch = MidiMaster.GetKnob(3);
        m_soundTimescale = MidiMaster.GetKnob(4);
        m_soundReverbDecay = MidiMaster.GetKnob(5);
        m_soundFeedback = MidiMaster.GetKnob(6);
        m_soundFilter = MidiMaster.GetKnob(7);
        m_soundSlide = MidiMaster.GetKnob(8);

        // Post Processing Data
        m_PPsaturation = MidiMaster.GetKnob(9);
		m_PPmotionBlur = MidiMaster.GetKnob(10);
        m_PPvignette = MidiMaster.GetKnob(11);

        // Reset BTN
        m_resetRowOne = MidiMaster.GetKnob(23);
		m_resetRowTwo = MidiMaster.GetKnob(24);
        m_resetRowThree = MidiMaster.GetKnob(25);
        m_resetRowFour = MidiMaster.GetKnob(26);
        m_resetRowFive = MidiMaster.GetKnob(27);
        m_resetRowSix = MidiMaster.GetKnob(28);
        m_resetRowSeven = MidiMaster.GetKnob(29);
        m_resetRowEight = MidiMaster.GetKnob(30);
        m_resetRowNine = MidiMaster.GetKnob(31);
    }


}