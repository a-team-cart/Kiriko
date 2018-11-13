using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public UDPSend UDPScript;
    private InputManager _inputMan;

    // Use this for initialization
    void Start () {
        _inputMan = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update () {
        UDPScript.SendData(serializeAudioParams());
    }

    //create string with all relevant audio
    //parameters for max to parse on its side
    private string serializeAudioParams()
    {
        return      _inputMan.m_saturation                      //overdrive
            + " " + _inputMan.m_timeSpeed                       //timescale
            + " " + _inputMan.m_soundPitch                      //pitch
            + " " + _inputMan.m_noiseIntensity                  //feedback
            + " " + Convert.ToInt32(_inputMan.m_lightState)     //delay status
            + " " + _inputMan.m_lightIntensity;                 //delay time
    }
}
