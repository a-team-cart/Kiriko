using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public UDPSend UDPScript;
    private inputManager _inputMan;

    // Use this for initialization
    void Start () {
        _inputMan = GetComponent<inputManager>();
    }

    // Update is called once per frame
    void Update () {
        UDPScript.SendData(serializeAudioParams());
    }

    //Create string with all relevant audio
    //arameters for max to parse on its side.
    private string serializeAudioParams()
    {
        var formattedString = 
            String.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}", 
            _inputMan.m_soundPitch, _inputMan.m_soundTimescale, _inputMan.m_soundReverbDecay, _inputMan.m_soundFeedback, _inputMan.m_soundFilter, _inputMan.m_soundSlide,
            _inputMan.m_PPsaturation, _inputMan.m_PPchromaticAberration, _inputMan.m_PPvignette, _inputMan.m_objectScale);
        return formattedString;
    }
}
